using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioOutput
    {
        public int UsuarioId { get; set; }
        public string Email_Usuario { get; set; }
        public int RolId { get; set; }
    }
}
