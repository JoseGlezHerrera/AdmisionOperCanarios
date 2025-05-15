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

namespace JoseCarlos.Application.UseCases.Usuarios.EliminarUsuario
{
    public class EliminarUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<EliminarUsuarioUseCase> _logger;

        public EliminarUsuarioUseCase(IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<EliminarUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }
        private void Validate(EliminarUsuarioInput input)
        {
            this._logger.LogInformation("EliminarUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
        }
        public void Execute(EliminarUsuarioInput input)
        {
            Validate(input);
            this._usuarioRepository.Delete(input.UsuarioId);
            this._uow.Save();
        }
    }
}