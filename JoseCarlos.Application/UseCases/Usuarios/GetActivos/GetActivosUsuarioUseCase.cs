using AutoMapper;
using JoseCarlos.Application.Interfaz;
using JoseCarlos.Application.UseCases.Usuarios.GetActivosUsuario;
using JoseCarlos.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.GetActivos
{
    public class GetActivosUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<GetActivosUsuarioUseCase> _logger;

        public GetActivosUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<GetActivosUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
            this._mapper = mapper;
        }
        public ICollection<GetActivosUsuarioOutput> Execute()
        {
            var entidades = this._usuarioRepository.GetAllIncludingRoles();

            var activos = entidades
                .Where(u => !u.Fecha_Baja_Usuario.HasValue || u.Fecha_Baja_Usuario == null)
                .ToList();

            this._logger.LogInformation($"GetActivos Usuarios Activos - Nº: {activos.Count}");

            return this.BuildOutPut(activos);
        }

        private ICollection<GetActivosUsuarioOutput> BuildOutPut(ICollection<JoseCarlos.Domain.Models.Usuario> usuarios)
        {
            var resultado = usuarios.Select(usuario => new GetActivosUsuarioOutput
            {
                UsuarioId = usuario.UsuarioId,
                Nombre_Usuario = usuario.Nombre_Usuario,
                Email_Usuario = usuario.Email_Usuario,
                Fecha_Creacion_Usuario = (DateTime)usuario.Fecha_Creacion_Usuario,
                Fecha_Baja_Usuario = usuario.Fecha_Baja_Usuario ?? DateTime.MinValue,
                RolId = usuario.RolId,
                RolNombre = usuario.Rol?.Nombre,
                Dni_Usuario = usuario.Dni_Usuario

            }).ToList();
            return resultado;
        }
    }
}