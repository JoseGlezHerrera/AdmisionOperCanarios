using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Domain.Models
{
    [Table("roles")]
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
    }
}
