using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.GetTodos;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.GetTodos
{
    public class GetTodosUsuarioMapping : Profile
    {
        public GetTodosUsuarioMapping()
        {
            CreateMap<GetTodosUsuarioOutput, GetTodosUsuarioResponse>();
        }
    }
}
