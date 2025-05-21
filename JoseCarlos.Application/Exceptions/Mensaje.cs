using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.Exceptions
{
    public static class Mensaje
    {
        public const string Usuario_Input = "El usuario no puede ser null";
        public static string USER_NULL(string dni) => $"El usuario con dni {dni} no existe";
        public static string DNI_DUPLICADO(string dni) => $"El dni {dni} ya existe";
        public static string Requerido(string propiedad) => $"El campo {propiedad} es requerido";
    }
}
