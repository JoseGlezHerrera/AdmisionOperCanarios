using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.GetActivosUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.GetActivos
{
    public class GetActivosUsuarioMapping : Profile
    {
        public GetActivosUsuarioMapping()
        {
            CreateMap<JoseCarlos.Domain.Models.Usuario, GetActivosUsuarioOutput>()
                .ForMember(dest => dest.Dni_Usuario, opt => opt.MapFrom(src => src.Dni_Usuario));
        }
    }
}
