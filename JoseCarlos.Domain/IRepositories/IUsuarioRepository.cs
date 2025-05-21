using JoseCarlos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Interfaz que define las operaciones de acceso a datos para la entidad Usuario,
// incluyendo métodos para obtener, crear, actualizar, eliminar usuarios, verificar existencia de DNI,
// autenticación de usuario y obtención de todos los usuarios (incluidos los eliminados).

namespace JoseCarlos.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Usuario? Get(int usuarioId);
        void Create (Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int usuarioId);
        bool ExisteDNI(int? UsuarioID, string Dni_Usuario);
        Usuario Login (string email, string contrasenia);
        ICollection<Usuario> GetAllIncludingEliminados();
        ICollection<Usuario> GetAllIncludingRoles();
    }
}
