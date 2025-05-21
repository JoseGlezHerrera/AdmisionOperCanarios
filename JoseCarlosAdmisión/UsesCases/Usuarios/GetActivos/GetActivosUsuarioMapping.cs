using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.GetActivosUsuario;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.GetActivos
{
    public class GetActivosUsuarioMapping : Profile
    {
        public GetActivosUsuarioMapping()
        {
            CreateMap<GetActivosUsuarioOutput, GetActivosUsuarioResponse>();
        }

    }
}
