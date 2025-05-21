using JoseCarlos.Application.UseCases.Usuarios.CambiarPasswordUsuario;
using JoseCarlosAdmisión.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.CambiarPasswordUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly CambiarPasswordUsuarioUseCase _useCase;
        private readonly IUsuarioApi _usuarioApi;
        public UsuarioController(CambiarPasswordUsuarioUseCase useCase, IUsuarioApi usuarioApi)
        {
            this._useCase = useCase;
            this._usuarioApi = usuarioApi;
        }
        [HttpPost("CambiarPassword")]
        public IActionResult CambiarPassword([FromBody,Required] CambiarPasswordUsuarioRequest request)
        {
            var input = new CambiarPasswordUsuarioInput()
            {
                contrasenia = request.contrasenia,
                UsuarioID = request.UsuarioID
            };
            var resultado = this._useCase.Execute(input);
            return Ok(new { mensaje = "Contraseña actualizada correctamente", resultado });
        }
    }
}
