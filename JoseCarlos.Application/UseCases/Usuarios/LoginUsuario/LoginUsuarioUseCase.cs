using AutoMapper;
using JoseCarlos.Application.Exceptions;
using JoseCarlos.Application.Interfaz;
using JoseCarlos.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<LoginUsuarioUseCase> _logger;
        public LoginUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<LoginUsuarioUseCase> logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }
        private void Validate(LoginUsuarioInput input)
        {
            this._logger.LogInformation("LoginUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (string.IsNullOrEmpty(input.Email_Usuario)) throw new ArgumentInputException(Mensaje.Requerido("Email"));
            if (string.IsNullOrEmpty(input.contrasenia)) throw new ArgumentInputException(Mensaje.Requerido("Contraseña"));            
        }
        public LoginUsuarioOutput Execute(LoginUsuarioInput input)
        {
            Validate(input);
            //Aqui va la encriptación de la contraseña. var passwordEncriptado = Encriptacion.Encriptar(input.Contrasenia);
            var usuario = this._usuarioRepository.Login(input.Email_Usuario, input.contrasenia); //<--Aqui iría passwordEncriptado)
            if (usuario == null) throw new UserNullException(Mensaje.USER_NULL(input.Email_Usuario));
            return this.BuildOutput(usuario);
        }
        private LoginUsuarioOutput BuildOutput(Domain.Models.Usuario usuario)
        {
            var resultado = this._mapper.Map<LoginUsuarioOutput>(usuario);
            return resultado;
        }
    }
}
