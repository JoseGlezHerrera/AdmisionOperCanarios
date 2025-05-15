namespace JoseCarlosAdmisión.Seguridad
{
    public class JWT
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ClaveSecreta { get; set; }
        public int TimeoutMinutos { get; set; }

    }
}
