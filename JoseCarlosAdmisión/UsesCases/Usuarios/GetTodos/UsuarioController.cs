using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.GetTodos;
using JoseCarlos.Domain.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.GetTodos
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly GetTodosUsuarioUseCase _useCase;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(GetTodosUsuarioUseCase useCase,IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this._useCase = useCase;
            this._usuarioRepository = usuarioRepository;
            this._mapper = mapper;
        }
        [HttpGet("GetTodos")]
        public IActionResult GetTodos()
        {
            var usuarios = this._usuarioRepository.GetAllIncludingEliminados();

            var resultado = usuarios.Select(usuario => new
            {
                usuario.UsuarioId,
                usuario.Nombre_Usuario,
                usuario.Email_Usuario,
                usuario.Edad_Usuario,
                usuario.Dni_Usuario,
                usuario.Fecha_Creacion_Usuario,
                usuario.Fecha_Baja_Usuario,
                usuario.Fecha_Modificacion_Usuario,
                usuario.Eliminado,
                usuario.contrasenia,
                usuario.RolId,
                RolNombre = usuario.Rol?.Nombre
            });
            return Ok(resultado);
        }
    }
}
