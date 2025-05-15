using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Domain.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int UsuarioId { get; set; }
        public string? Nombre_Usuario { get; set; }
        public string? Email_Usuario { get; set; }
        public int? Edad_Usuario { get; set; }
        public string? Dni_Usuario { get; set; }
        public DateTime Fecha_Creacion_Usuario { get; set; }
        public bool? Eliminado { get; set; }
        public string? contrasenia { get; set; }
        public DateTime? Fecha_Baja_Usuario { get; set; }
        public DateTime Fecha_Modificacion_Usuario { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
