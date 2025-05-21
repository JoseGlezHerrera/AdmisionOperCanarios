namespace JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario
{
    public class CrearUsuarioResponse
    {
        public int UsuarioID { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public string Dni_Usuario { get; set; }
        public string contrasenia { get; set; }
        public int RolId { get; set; }
        public DateTime Fecha_Creacion_Usuario { get; set; } = DateTime.Now;
    }
}
