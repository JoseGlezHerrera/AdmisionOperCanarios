using AutoMapper;
using JoseCarlos.Application.Interfaz;
using JoseCarlos.Domain.IRepositories;
using JoseCarlos.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.GetTodos
{
    public class GetTodosUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<GetTodosUsuarioUseCase> _logger;
        public GetTodosUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<GetTodosUsuarioUseCase> logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }
        public ICollection<GetTodosUsuarioOutput>Execute()
        {
            var entidad = this._usuarioRepository.GetAllIncludingEliminados().ToList();
            this._logger.LogInformation($"GetTodos Usuarios - Nº:{entidad.Count}");
            return this.BuildOutput(entidad);
        }

        private ICollection<GetTodosUsuarioOutput> BuildOutput(ICollection<Usuario> usuarios)
        {
            var resultado = usuarios.Select(usuario => new GetTodosUsuarioOutput
            {
                UsuarioId = usuario.UsuarioId,
                Nombre_Usuario = usuario.Nombre_Usuario,
                Email_Usuario = usuario.Email_Usuario,
                Fecha_Creacion_Usuario = usuario.Fecha_Creacion_Usuario,
                Fecha_Baja_Usuario = usuario.Fecha_Baja_Usuario ?? DateTime.MinValue,
                RolId = usuario.RolId,
                RolNombre = usuario.Rol?.Nombre,
                Dni_Usuario = usuario.Dni_Usuario
            }).ToList();
            return resultado;
        }

    }
}
