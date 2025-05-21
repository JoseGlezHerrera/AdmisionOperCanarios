using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Domain.Seguridad
{
    public static class GeneradorClave
    {
        public static string Token(int longitud)
        {
            if (longitud < 1 || longitud > 32)
                throw new ArgumentOutOfRangeException(nameof(longitud), "La longitud debe estar entre 1 y 32.");
            return Guid.NewGuid().ToString("n").Substring(0, longitud);
        }
    }
}