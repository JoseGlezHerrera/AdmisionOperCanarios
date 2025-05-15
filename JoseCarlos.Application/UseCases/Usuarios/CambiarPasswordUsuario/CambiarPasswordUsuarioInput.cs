using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.CambiarPasswordUsuario
{
    public class CambiarPasswordUsuarioInput
    {
        public int UsuarioID { get; set; }
        public string contrasenia { get; set; }
        
    }
}
