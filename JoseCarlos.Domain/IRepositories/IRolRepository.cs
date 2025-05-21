using JoseCarlos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Domain.IRepositories
{
    public interface IRolRepository
    {
        ICollection<Rol> GetAll();
        int GetId(int UsuarioId);
    }
}
