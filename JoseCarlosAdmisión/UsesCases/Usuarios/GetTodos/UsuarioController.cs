using AutoMapper;
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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this._usuarioRepository = usuarioRepository;
            this._mapper = mapper;
        }
        [HttpGet("GetTodos")]
        public IActionResult GetTodos()
        {
            var usuarios = this._usuarioRepository.GetAllIncludingEliminados();
            return Ok(usuarios);
        }
    }
}
