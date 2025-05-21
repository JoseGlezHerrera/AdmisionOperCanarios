using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using JoseCarlos.Application.UseCases.Usuarios.GetActivos;
using JoseCarlos.Domain.IRepositories;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.GetActivosUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly GetActivosUsuarioUseCase _useCase;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(GetActivosUsuarioUseCase useCase, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            this._useCase = useCase;
            this._mapper = mapper;
            this._usuarioRepository = usuarioRepository;
        }
        [HttpGet("GetActivos")]
        public IActionResult GetActivos()
        {
            var usuariosConRoles = this._usuarioRepository.GetAllIncludingRoles();
            var resultado = this._useCase.Execute();
            return Ok(resultado);
        }
    }
}