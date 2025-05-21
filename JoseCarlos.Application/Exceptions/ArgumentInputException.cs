using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.Exceptions
{
    public class ArgumentInputException : Exception
    {
        public ArgumentInputException() : base() { }
        public ArgumentInputException(string message) : base(message) { }

        protected ArgumentInputException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
        
    }
}
