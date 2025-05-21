using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.CrearUsuario;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario
{
    public class CrearUsuarioMapping : Profile
    {
        public CrearUsuarioMapping()
        {
            CreateMap<CrearUsuarioRequest, CrearUsuarioInput>();
            CreateMap<CrearUsuarioOutput, CrearUsuarioResponse>();
        }
    }
}
