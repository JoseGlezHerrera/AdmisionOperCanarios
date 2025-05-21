using JoseCarlos.Domain.IRepositories;
using JoseCarlos.Domain.Models;
using JoseCarlos.Infraestructure.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Infraestructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly GestionContext _context;
        public RolRepository(GestionContext context)
        {
            this._context = context;
        }
        public ICollection<Rol> GetAll()
        {
            return this._context.Roles.ToList();
        }
        public int GetId(int UsuarioId)
        {
            return this._context.Usuario.Where(u => u.UsuarioId == UsuarioId).Select(u => u.RolId).FirstOrDefault();
        }
    }
}
