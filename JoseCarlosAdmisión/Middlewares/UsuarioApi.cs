namespace JoseCarlosAdmisión.Middlewares
{
    public interface IUsuarioApi
    {
        int UsuarioId { get; set; }
        void Insertar(int usuarioId);
    }
    public class  UsuarioApi : IUsuarioApi
    {
        public int UsuarioId { get;  set; }
        public UsuarioApi()
        {
            this.UsuarioId = 1;
        }
        public void Insertar(int usuarioId)
        {
            this.UsuarioId = usuarioId;
        }
    }
}
