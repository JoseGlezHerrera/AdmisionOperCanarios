namespace JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario
{
    public class CrearUsuarioRequest
    {
        public int UsuarioID { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public string Dni_Usuario { get; set; }
        public int Edad_Usuario { get; set; }
        public int RolId { get; set; }
        public string contrasenia { get; set; }
        public DateTime Fecha_Creacion_Usuario { get; set; } = DateTime.Now;
        public bool Eliminado { get; set; } = false;
    }
}
