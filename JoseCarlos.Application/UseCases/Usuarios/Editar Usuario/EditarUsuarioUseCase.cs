using AutoMapper;
using JoseCarlos.Application.Exceptions;
using JoseCarlos.Application.Interfaz;
using JoseCarlos.Domain.IRepositories;
using JoseCarlos.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario
{
    public class EditarUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<EditarUsuarioUseCase> _logger;

        public EditarUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<EditarUsuarioUseCase>logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }

        private void Validate(EditarUsuarioInput input)
        {
            this._logger.LogInformation($"EditarUsuarioInput es : {input}");
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioID == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioID"));
            if (string.IsNullOrEmpty(input.Dni_Usuario)) throw new ArgumentInputException(Mensaje.Requerido("Falta el Dni_Usuario"));
            if (this._usuarioRepository.ExisteDNI(input.UsuarioID, input.Dni_Usuario)) 
                throw new ArgumentInputException(Mensaje.DNI_DUPLICADO(input.Dni_Usuario));
            if (string.IsNullOrEmpty(input.Nombre_Usuario)) throw new ArgumentInputException(Mensaje.Requerido("Falta el nombre"));
            if (string.IsNullOrEmpty(input.Email_Usuario)) throw new ArgumentInputException(Mensaje.Requerido("Falta el Email_Usuario"));
            if (input.Edad_Usuario == 0) throw new ArgumentInputException(Mensaje.Requerido("Falta la edad del usuario"));
        }
        public EditarUsuarioOutput Execute(EditarUsuarioInput input)
        {
            Validate(input);
            var usuario = this._usuarioRepository.Get(input.UsuarioID);
            usuario.Nombre_Usuario = input.Nombre_Usuario;
            usuario.Email_Usuario = input.Email_Usuario;
            usuario.Edad_Usuario = input.Edad_Usuario;
            usuario.Dni_Usuario = input.Dni_Usuario;
            usuario.Fecha_Modificacion_Usuario = DateTime.Now;
            usuario.Fecha_Baja_Usuario = input.Fecha_Baja_Usuario;

            this._usuarioRepository.Update(usuario);
            this._uow.Save();
            return this.BuildOutput(usuario);

        }
        private EditarUsuarioOutput BuildOutput(Usuario usuario)
        {
            var res = this._mapper.Map<Usuario, EditarUsuarioOutput>(usuario);
            return res;
        }
    }
}
