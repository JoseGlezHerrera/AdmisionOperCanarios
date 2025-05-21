using JoseCarlos.Application.Exceptions;
using JoseCarlos.Application.Interfaz;
using JoseCarlos.Domain.Correo;
using JoseCarlos.Domain.IRepositories;
using JoseCarlos.Domain.Models;
using JoseCarlos.Domain.Seguridad;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.ResetearUsuario
{
    public class ResetearUsuarioUseCase
    {
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IGestionCorreo _gestionCorreo;
        private readonly ILogger<ResetearUsuarioUseCase> _logger;
        
        public ResetearUsuarioUseCase(IGestionUOW uow, IUsuarioRepository usuarioRepository, IGestionCorreo gestionCorreo, ILogger<ResetearUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._gestionCorreo = gestionCorreo;
            this._logger = logger;
        }
        private void Validate (ResetearUsuarioInput input)
        {
            this._logger.LogInformation("ResetearUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
        }
        public Boolean Execute (ResetearUsuarioInput input)
        {
            Validate(input);
            var usuario = this._usuarioRepository.Get(input.UsuarioId);
            var nuevaClave = GeneradorClave.Token(6);
            var claveEncriptada = Encriptacion.Encriptar(nuevaClave);
            usuario.contrasenia = claveEncriptada;
            usuario.Fecha_Modificacion_Usuario = DateTime.Now;
            this._uow.Save();
            this.EnviarNotificacion(usuario, nuevaClave);
            return true;
        }
        public void EnviarNotificacion(Usuario usuario, string nuevaClave)
        {
            Task.Run(() =>
            {
                this._gestionCorreo.Enviar("Belingo Gestión Directo: Restablecimiento de contraseña al usuario", usuario.Notificacion(nuevaClave), usuario.Email_Usuario);
            });
        }
    }
}
