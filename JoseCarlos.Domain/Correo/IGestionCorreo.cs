using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Domain.Correo
{
    public interface IGestionCorreo
    {
        string[] Destinatarios { get; set; }
        string Enviar(string cabecera, string mensaje);
        string Enviar(string cabecera, string mensaje, string destinatario);
    }
}
