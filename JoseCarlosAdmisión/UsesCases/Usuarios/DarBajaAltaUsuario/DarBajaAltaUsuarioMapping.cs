using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.DarBajaAltaUsuario;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.DarBajaAltaUsuario
{
    public class DarBajaAltaUsuarioMapping : Profile
    {
        public DarBajaAltaUsuarioMapping()
        {
            CreateMap<DarBajaAltaUsuarioRequest, DarBajaAltaUsuarioInput>();
            CreateMap<DarBajaAltaUsuarioOutput, DarBajaAltaUsuarioResponse>();
        }
    }
}
