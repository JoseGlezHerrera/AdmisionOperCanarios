using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Domain.Correo
{
    public interface IConfigCorreo
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Destinatarios { get; set; }
    }
}
