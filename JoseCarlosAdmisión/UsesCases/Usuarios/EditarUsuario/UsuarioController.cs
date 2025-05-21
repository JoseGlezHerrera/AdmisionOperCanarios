using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace JoseCarlosAdmisión.UsesCases.Usuarios.EditarUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly EditarUsuarioUseCase _useCase;
        private readonly IMapper _mapper;

        public UsuarioController(EditarUsuarioUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }
        [HttpPost("Editar")]
        public IActionResult Editar([Required] EditarUsuarioRequest request)
        {
            var input = this._mapper.Map<EditarUsuarioRequest, EditarUsuarioInput>(request);
            var output = this._useCase.Execute(input);
            return Ok(output);
        }
    }
}
