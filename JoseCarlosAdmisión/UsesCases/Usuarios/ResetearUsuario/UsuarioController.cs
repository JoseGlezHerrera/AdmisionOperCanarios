using JoseCarlos.Application.UseCases.Usuarios.ResetearUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.ResetearUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly ResetearUsuarioUseCase _useCase;
        public UsuarioController(ResetearUsuarioUseCase useCase)
        {
            this._useCase = useCase;
        }
        [HttpPost("Resetear")]
        public IActionResult Resetear([Required] ResetearUsuarioRequest request)
        {
            var input = new ResetearUsuarioInput() { UsuarioId = request.UsuarioId };
            var resultado = this._useCase.Execute(input);
            return Ok(resultado);
        }
    }
}
