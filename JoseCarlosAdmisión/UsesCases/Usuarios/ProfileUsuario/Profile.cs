using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.CrearUsuario;
using JoseCarlos.Domain.Models;
using JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.ProfileUsuario
{
    public class CrearUsuarioMappingProfile : Profile
    {
        public CrearUsuarioMappingProfile()
        {
            CreateMap<CrearUsuarioRequest, CrearUsuarioInput>()
                .ForMember(dest => dest.Nombre_Usuario, opt => opt.MapFrom(src => src.Nombre_Usuario))
                .ForMember(dest => dest.Edad_Usuario, opt => opt.MapFrom(src => src.Edad_Usuario))
                .ForMember(dest => dest.Email_Usuario, opt => opt.MapFrom(src => src.Email_Usuario))
                .ForMember(dest => dest.contrasenia, opt => opt.MapFrom(src => src.contrasenia));

            CreateMap<CrearUsuarioInput, CrearUsuarioOutput>()
                .ForMember(dest => dest.Nombre_Usuario, opt => opt.MapFrom(src => src.Nombre_Usuario))
                .ForMember(dest => dest.Edad_Usuario, opt => opt.MapFrom(src => src.Edad_Usuario))
                .ForMember(dest => dest.Email_Usuario, opt => opt.MapFrom(src => src.Email_Usuario))
                .ForMember(dest => dest.Fecha_Creacion_Usuario, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Fecha_Baja_Usuario, opt => opt.MapFrom(src => DateTime.Now.AddYears(1)));
            CreateMap<Usuario, CrearUsuarioOutput>()
                .ForMember(dest => dest.UsuarioID, opt => opt.MapFrom(src => src.UsuarioId));




        }
    }
}
