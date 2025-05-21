using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario
{
    public class EditarUsuarioInput
    {
        public int UsuarioID { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public int Edad_Usuario { get; set; }
        public string Dni_Usuario { get; set; }
        public bool Eliminado { get; set; }
        public DateTime? Fecha_Baja_Usuario { get; set; }
        public int RolId { get; set; }
    }
}
