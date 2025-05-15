using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.DarBajaAltaUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.DarBajaAltaUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private readonly DarBajaAltaUsuarioUseCase _useCase;
        private readonly IMapper _mapper;
        public UsuarioController(DarBajaAltaUsuarioUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }
        [HttpPost("DarBajaAlta")]
        public IActionResult DarBajaAlta([Required] DarBajaAltaUsuarioRequest request)
        {
            var input = this._mapper.Map<DarBajaAltaUsuarioRequest, DarBajaAltaUsuarioInput>(request);
            var output = this._useCase.Execute(input);
            if (output.Fecha_Baja_Usuario == null)
            {
                return BadRequest("FechaBajaUsuario no está siendo asignada correctamente");
            }
            return Ok(output);
        }
    }
}
