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
        public string Notificacion (string nuevaClave)
        {
            string resultado = $"Se establece una nueva contraseña para el usuario{this.Nombre_Usuario} con DNI {this.Dni_Usuario} y email {this.Email_Usuario}. " +
                $"La nueva contraseña es: {nuevaClave}. " +
                $"Recuerde cambiarla al iniciar sesión.";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Estimado usuario:");
            sb.AppendLine(this.Nombre_Usuario);
            sb.AppendLine("Se ha solicitado un restablecimiento de contraseña.");
            sb.AppendLine("Su nueva contraseña es: " + nuevaClave);
            sb.AppendLine("Por favor, cambie su contraseña después de iniciar sesión.");
            sb.AppendLine("Si no solicitó este cambio, comuníquese con el soporte técnico.");
            sb.AppendLine("Saludos,");
            sb.AppendLine("El equipo de soporte");
            sb.AppendLine("Belingo Gestión Directo");
            return sb.ToString();
        }
    }
}
