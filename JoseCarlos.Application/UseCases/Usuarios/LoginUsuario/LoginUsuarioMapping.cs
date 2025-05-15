using AutoMapper;
using JoseCarlos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioMapping : Profile
    {
        public LoginUsuarioMapping()
        {
            CreateMap<Usuario, LoginUsuarioOutput>()
                .ForMember(dest => dest.Email_Usuario, opt => opt.MapFrom(src => src.Email_Usuario));
            CreateMap<LoginUsuarioInput, Usuario>();

        }
    }
}
