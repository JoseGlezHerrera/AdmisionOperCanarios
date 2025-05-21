using System.ComponentModel.DataAnnotations;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioRequest
    {
        [Required]
        public string Email_Usuario { get; set; }
        [Required]
        public string Contrasenia { get; set; }
    }
}
