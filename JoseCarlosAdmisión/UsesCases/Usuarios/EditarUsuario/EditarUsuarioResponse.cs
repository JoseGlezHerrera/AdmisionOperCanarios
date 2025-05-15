namespace JoseCarlosAdmisión.UsesCases.Usuarios.EditarUsuario
{
    public class EditarUsuarioResponse
    {
        public int UsuarioID { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public int Edad_Usuario { get; set; }
        public string Dni_Usuario { get; set; }
        public DateTime Fecha_Creacion_Usuario { get; set; } = DateTime.Now;
        public bool Eliminado { get; set; } = false;

        public DateTime Fecha_Alta_Usuario { get; set; }
        public DateTime Fecha_Modificacion_Usuario { get; set; }
        public DateTime? Fecha_Baja_Usuario { get; set; }
        public int RolId { get; set; }
    }
}
