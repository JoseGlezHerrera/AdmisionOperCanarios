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

namespace JoseCarlos.Application.UseCases.Usuarios.CambiarPasswordUsuario
{
    public class CambiarPasswordUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<CambiarPasswordUsuarioUseCase> _logger;
    public CambiarPasswordUsuarioUseCase(IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<CambiarPasswordUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }
    public void Validate(CambiarPasswordUsuarioInput input)
        {
            this._logger.LogInformation("CambiarPasswordUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioID == 0) throw new ArgumentInputException(Mensaje.Requerido("Id del Usuario"));
        }

    public Boolean Execute(CambiarPasswordUsuarioInput input)
        {
            Validate(input);
            var usuario = this._usuarioRepository.Get(input.UsuarioID);
            usuario.contrasenia = input.contrasenia; // luego poner esta para la encriptacion usuario.Fecha_Modificacion_Usuario = DateTime.Now;
            this._uow.Save();
            return true;
        }
    }
}
