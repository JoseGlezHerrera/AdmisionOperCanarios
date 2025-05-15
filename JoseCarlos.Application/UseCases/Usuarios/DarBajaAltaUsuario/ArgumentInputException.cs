using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.DarBajaAltaUsuario
{
    [Serializable]
    internal class ArgumentInputException : Exception
    {
        public ArgumentInputException()
        {
        }
        public ArgumentInputException(string? message) : base(message)
        {

        }
        public ArgumentInputException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
