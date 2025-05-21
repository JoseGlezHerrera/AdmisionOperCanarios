using JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario;
using JoseCarlos.Application.UseCases.Usuarios.EliminarUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.EliminarUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly EliminarUsuarioUseCase _useCase;
        public UsuarioController(EliminarUsuarioUseCase useCase)
        {
            this._useCase = useCase;
        }
        [HttpDelete("{UsuarioId}")]
        public IActionResult Eliminar(int UsuarioId)
        {
            var input = new EliminarUsuarioInput() { UsuarioId = UsuarioId };
            this._useCase.Execute(input);
            return Ok(true);
        }
    }
}
