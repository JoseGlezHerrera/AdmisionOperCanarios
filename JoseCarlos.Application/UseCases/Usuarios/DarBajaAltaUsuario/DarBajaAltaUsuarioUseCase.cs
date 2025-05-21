using AutoMapper;
using JoseCarlos.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.DarBajaAltaUsuario
{
    public class DarBajaAltaUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public DarBajaAltaUsuarioUseCase(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }
        private void Validate(DarBajaAltaUsuarioInput input)
        {
            if (input == null) throw new ArgumentNullException("El input no puede ser nulo.");
            if (string.IsNullOrEmpty(input.UsuarioID)) throw new ArgumentException("El ID del usuario es requerido");
        }
        public DarBajaAltaUsuarioOutput Execute(DarBajaAltaUsuarioInput input)
        {
            Validate(input);

            var usuario = _usuarioRepository.Get(int.Parse(input.UsuarioID));

            if (usuario == null) throw new ArgumentException("Usuario no encontrado");

            usuario.Fecha_Baja_Usuario = DateTime.Now;

            _usuarioRepository.Update(usuario);

            var output = new DarBajaAltaUsuarioOutput
            {
                UsuarioID = usuario.UsuarioId.ToString(),
                Fecha_Baja_Usuario = usuario.Fecha_Baja_Usuario.Value
            };
            return output;
        }
    }
}
