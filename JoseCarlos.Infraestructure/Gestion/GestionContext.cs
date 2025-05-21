using JoseCarlos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Contexto de base de datos para la gestión de usuarios y roles.
/// Utiliza Entity Framework Core para mapear las entidades "Usuario" y "Rol".
/// Configura la conexión a MySQL y proporciona métodos utilitarios como "DetachAllEntities".
/// </summary>

namespace JoseCarlos.Infraestructure.Gestion
{
    public class GestionContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly string _conexion;
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public GestionContext(DbContextOptions<GestionContext>options): base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_conexion, new MySqlServerVersion(new Version(8, 0, 31)));
            }
        }
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

    }
}
