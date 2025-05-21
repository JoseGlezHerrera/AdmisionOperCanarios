using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.LoginUsuario;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioMapping : Profile
    {
        public LoginUsuarioMapping()
        {
            CreateMap<LoginUsuarioRequest, LoginUsuarioInput>();
            CreateMap<LoginUsuarioOutput, LoginUsuarioResponse>();
        }
    }
}