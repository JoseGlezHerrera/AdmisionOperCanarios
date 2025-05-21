using JoseCarlos.Domain.Correo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Infraestructure.Correo
{
    public class GestionCorreo : IGestionCorreo
    {
        private string usuario;
        private SmtpClient gestorEmail;

        public string[] Destinatarios { get; set; }
        public GestionCorreo(IConfigCorreo configuracion)
        {
            if (configuracion != null)
            {
                try
                {
                    //Muestra la configuración cargada para depuración.
                    Console.WriteLine($"Servidor: {configuracion.Servidor}, Puerto: {configuracion.Puerto}, Usuario: {configuracion.Usuario}, Destinatarios: {configuracion.Destinatarios}");
                    //Validamos que el puerto sea un número positivo
                    if (configuracion.Puerto <= 0)
                    {
                        throw new Exception("El puerto configurado no es válido.");
                    }
                    //Configurar el cliente SMTP
                    this.gestorEmail = new SmtpClient(configuracion.Servidor)
                    {
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        EnableSsl = true,
                        Port = configuracion.Puerto,
                        Credentials = new System.Net.NetworkCredential(configuracion.Usuario, configuracion.Contrasenia)
                    };
                    //Cargar los destinatarios
                    this.Destinatarios = this.ObtenerDestinatarios(configuracion);
                    this.usuario = configuracion.Usuario;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Error en la configuración del correo: {error.Message}");
                    throw new Exception("El correo no está configurado correctamente.", error);
                }
            }
            else
            {
                throw new Exception("El correo no está configurado correctamente");
            }
        }
        private String[] ObtenerDestinatarios(IConfigCorreo configuracion)
        {
            var destinatariosResponsables = configuracion.Destinatarios.Split(',');
            var destinatarios = configuracion.Destinatarios.Split(',');
            return destinatariosResponsables.Concat(destinatarios).ToArray();
        }
        public string Enviar(string cabecera, string mensaje)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(this.usuario);
                mail.IsBodyHtml = true;
                foreach (string destinatario in this.Destinatarios)
                {
                    mail.To.Add(destinatario);
                }
                mail.Subject = cabecera;
                mail.Body = mensaje;
                this.gestorEmail.Send(mail);
                return string.Empty;
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }
        public string Enviar(string cabecera, string mensaje, string destinatario)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(this.usuario);
                mail.IsBodyHtml = true;
                mail.To.Add(destinatario);
                mail.Subject = cabecera;
                mail.Body = mensaje;
                this.gestorEmail.Send(mail);
                return string.Empty;
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }
    }
}
