using AutoMapper;
using JoseCarlos.Application.Exceptions;
using JoseCarlos.Domain.Models;
using JoseCarlos.Infraestructure.Gestion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.CrearUsuario
{
    public class CrearUsuarioUseCase
    {
        private readonly ILogger<CrearUsuarioUseCase> logger;
        private readonly IMapper mapper;
        private readonly GestionContext context;
        public CrearUsuarioUseCase(IMapper mapper, ILogger<CrearUsuarioUseCase>logger,GestionContext context)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.context = context;
        }
        public void Validate(CrearUsuarioInput input)
        {
            if (string.IsNullOrEmpty(input.Nombre_Usuario)) throw new ArgumentInputException(Mensaje.Requerido("Nombre_Usuario"));
            if (string.IsNullOrEmpty(input.Email_Usuario)) throw new ArgumentInputException(Mensaje.Requerido("Email_Usuario"));
            if (string.IsNullOrEmpty(input.Dni_Usuario)) throw new ArgumentInputException(Mensaje.Requerido("Dni_Usuario"));
            if (context.Usuario.Any(u => u.Dni_Usuario == input.Dni_Usuario))
            {
                throw new ArgumentInputException("Dni_Usuario ya en uso.");
            }

        }
        public CrearUsuarioOutput Execute(CrearUsuarioInput input)
        {
            Validate(input);
            var usuario = new Usuario
            {
                Nombre_Usuario = input.Nombre_Usuario,
                Email_Usuario = input.Email_Usuario,
                Dni_Usuario = input.Dni_Usuario,
                Fecha_Creacion_Usuario = DateTime.Now,
                Edad_Usuario = (int)input.Edad_Usuario,
                contrasenia = input.contrasenia,
                RolId = input.RolId
            };
            context.Usuario.Add(usuario);
            context.SaveChanges();
            return mapper.Map<CrearUsuarioOutput>(usuario);
        }
    }
}
