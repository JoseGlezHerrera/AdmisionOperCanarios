using JoseCarlos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Infraestructure.Gestion
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IInfrastructure<IServiceProvider>, IDbContextDependencies, IDbSetCache, IDbContextPoolable
    {
        private readonly DbContextOptions _options;
        private readonly IServiceProvider _serviceProvider;
        private IDictionary<(Type Type, string? Name), object>? _sets;
        private IDbContextServices? _contextServices;
        private IDbContextDependencies? _dbContextDependencies;
        private DatabaseFacade? _database;

        private bool _disposed;
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        public DbContext(DbContextOptions options) : base(options)
        {
            if(!options.ContextType.IsAssignableFrom(GetType()))
            {
                throw new InvalidOperationException(CoreStrings.NonGenericOptions(GetType().ShortDisplayName()));
            }
            EntityFrameworkEventSource.Log.DbContextInitializing();
        }
        public DbContext() : this(new DbContextOptions<DbContext>())
        { 
        }
        public IServiceProvider Instance => _serviceProvider;
        public DatabaseFacade Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DatabaseFacade(this);
                }
                return Database;
            }
        }
        public ChangeTracker ChangeTracker => base.ChangeTracker;
        public object GetOrAddSet(DbContext context, Type type)
        {
            _sets ??= new Dictionary<(Type, string?), object>();
            var key = (type, (string?)null);
            if (!_sets.ContainsKey(key))
            {
                var method = typeof(DbContext).GetMethod("Set", new Type[] { });
                var genericMethod = method.MakeGenericMethod(type);
                var dbSet = genericMethod.Invoke(context, null);
                _sets[key] = dbSet;
            }
            return _sets[key];
        }
        public object GetOrAddSet(IDbSetSource source, string entityTypeName, Type type)
        {
            _sets ??= new Dictionary<(Type, string?), object>();
            var key = (type, entityTypeName);
            if (!_sets.ContainsKey(key))
            {
                _sets[key] = Activator.CreateInstance(type);
            }
            return _sets[key];
        }
        public IEnumerable<object> GetSets() => _sets?.Values ?? Enumerable.Empty<object>();
        public object GetService(Type serviceType) => _serviceProvider.GetService(serviceType);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("DefaultConnection",
                    new MySqlServerVersion(new Version(5, 7, 11)));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Eliminado)
                .HasConversion<int>();
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }
        public void SetLease(DbContextLease lase) { }
        public Task SetLeaseAsync(DbContextLease lease, CancellationToken cancelattionToken) => Task.CompletedTask;
        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
        }
        public override ValueTask DisposeAsync()
        {
            Dispose();
            return new ValueTask();
        }
    }
}