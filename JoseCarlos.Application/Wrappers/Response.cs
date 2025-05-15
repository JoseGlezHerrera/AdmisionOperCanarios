using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.Wrappers
{
    public class Response<T>
    {
        public bool succeeded { get; set; }
        public string message { get; set; }
        public List<string> errores { get; set; }
        public T? data { get; set; }
        public Response()
        {
            this.message = String.Empty;
            this.errores = new List<string>();
        }
        public Response(T data, string message = null)
        {
            this.succeeded = true;
            this.message = message;
            this.data = data;
        }
        public Response(string message)
        {
            this.succeeded = false;
            this.message = message;
        }
    }
}
