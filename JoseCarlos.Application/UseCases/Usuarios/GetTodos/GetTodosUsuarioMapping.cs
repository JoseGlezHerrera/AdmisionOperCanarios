using AutoMapper;
using JoseCarlos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.UseCases.Usuarios.GetTodos
{
     public class GetTodosUsuarioMapping : Profile
    {
        public GetTodosUsuarioMapping()
        {
            CreateMap<Usuario, GetTodosUsuarioOutput>();
        }
    }
}
