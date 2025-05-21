using JoseCarlos.Domain.IRepositories;
using JoseCarlos.Domain.Models;
using JoseCarlos.Infraestructure.Gestion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Repositorio para la gestión de entidades Usuario en la base de datos.
// Implementa operaciones CRUD, validación de existencia por DNI, login y recuperación de usuarios (incluyendo eliminados).
// Utiliza Entity Framework Core y el contexto GestionContext para interactuar con la tabla "usuarios".

namespace JoseCarlos.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GestionContext _context;
        public UsuarioRepository(GestionContext context)
        {
            _context = context;
        }
        public void Create(Usuario usuario) => _context.Usuario.Add(usuario);

        public void Delete(int UsuarioId)
        {
            var entidad = Get(UsuarioId);
            if (entidad == null) throw new ArgumentException("No existe el usuario", nameof(UsuarioId));
            entidad.Eliminado = true;
            _context.Entry(entidad).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Usuario? Get(int UsuarioId) => _context.Usuario.FirstOrDefault(u => u.UsuarioId == UsuarioId);

        public void Update(Usuario usuario)
        {
            var entidad = _context.Usuario.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);
            if (entidad == null) return;
            if (usuario.Nombre_Usuario != entidad.Nombre_Usuario) entidad.Nombre_Usuario = usuario.Nombre_Usuario;
            if (usuario.Dni_Usuario != entidad.Dni_Usuario) entidad.Dni_Usuario = usuario.Dni_Usuario;
            if (usuario.contrasenia != entidad.contrasenia) entidad.contrasenia = usuario.contrasenia;
            if (usuario.Email_Usuario != entidad.Email_Usuario) entidad.Email_Usuario = usuario.Email_Usuario;
            _context.SaveChanges();
        }

        public bool ExisteDNI(int? usuarioID, string dni)
        {
            if (!usuarioID.HasValue)
            {
                return this._context.Usuario.Any(u => u.Dni_Usuario == dni && (u.Eliminado ?? false) == false);
            }
            else
            {
                return this._context.Usuario.Any(u => u.Dni_Usuario == dni && (u.Eliminado ?? false) == false && u.UsuarioId != usuarioID.Value);
            }
        }

        public Usuario? Login(string email, string contrasenia)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email_Usuario == email && u.contrasenia == contrasenia && (u.Eliminado ?? false) == false);
        }

        public ICollection<Usuario> GetAllIncludingEliminados()
        {
            return _context.Usuario
                .Include( u => u.Rol)
                .ToList();
        }
        public ICollection<Usuario> GetAllIncludingRoles()
        {
            return _context.Usuario
                .Include(u => u.Rol)
                .Where(u => u.Eliminado == false || u.Eliminado == null)
                .ToList();
        }
    }
}