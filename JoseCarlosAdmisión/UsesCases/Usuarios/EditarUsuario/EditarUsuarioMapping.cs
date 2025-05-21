using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.EditarUsuario
{
    public class EditarUsuarioMapping : Profile
    {
        public EditarUsuarioMapping()
        {
            CreateMap<EditarUsuarioRequest, EditarUsuarioInput>()
                .ForMember(dest => dest.Nombre_Usuario, opt => opt.MapFrom(src => src.Nombre_Usuario))
                .ForMember(dest => dest.Dni_Usuario, opt => opt.MapFrom(src => src.Dni_Usuario));

            CreateMap<EditarUsuarioOutput, EditarUsuarioInput>()
                .ForMember(dest => dest.Dni_Usuario, opt => opt.MapFrom(src => src.Dni_Usuario))
                .ForMember(dest => dest.Nombre_Usuario, opt => opt.MapFrom(src => src.Nombre_Usuario));
        }
    }
}
