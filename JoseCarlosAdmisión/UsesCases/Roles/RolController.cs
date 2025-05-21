using JoseCarlos.Application.UseCases.Usuarios.GetTodos;
using Microsoft.AspNetCore.Mvc;

namespace JoseCarlosAdmisión.UsesCases.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly GetTodosUsuarioUseCase _useCase;
        public RolController(GetTodosUsuarioUseCase useCase)
        {
            this._useCase = useCase;
        }
        [HttpGet("GetTodos")]
        public IActionResult GetAll()
        {
            var output = this._useCase.Execute();
            return Ok(output);
        }
    }
}
