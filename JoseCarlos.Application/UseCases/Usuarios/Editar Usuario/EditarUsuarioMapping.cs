using AutoMapper;
using JoseCarlos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario
{
    public class EditarUsuarioMapping : Profile
    {
        public EditarUsuarioMapping()
        {
            CreateMap<Usuario, EditarUsuarioOutput>()
                .ForMember(dest => dest.UsuarioID, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.Nombre_Usuario, opt => opt.MapFrom(src => src.Nombre_Usuario))
                .ForMember(dest => dest.Email_Usuario, opt => opt.MapFrom(src => src.Email_Usuario))
                .ForMember(dest => dest.Edad_Usuario, opt => opt.MapFrom(src => src.Edad_Usuario ?? 0))
                .ForMember(dest => dest.Dni_Usuario, opt => opt.MapFrom(src => src.Dni_Usuario))
                .ForMember(dest => dest.Eliminado, opt => opt.MapFrom(src => src.Eliminado ?? false))
                .ForMember(dest => dest.Fecha_Alta_Usuario, opt => opt.MapFrom(src => src.Fecha_Creacion_Usuario))
                .ForMember(dest => dest.Fecha_Modificacion_Usuario, opt => opt.MapFrom(src => (DateTime?)src.Fecha_Modificacion_Usuario))
                .ForMember(dest => dest.RolNombre, opt => opt.MapFrom(src => src.Rol))
                .ForMember(dest => dest.Fecha_Baja_Usuario, opt => opt.MapFrom(src => src.Fecha_Baja_Usuario));
        }
    }
}
