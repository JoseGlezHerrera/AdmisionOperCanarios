using AutoMapper;
using JoseCarlos.Application.Exceptions;
using JoseCarlos.Application.UseCases.Usuarios.CrearUsuario;
using JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario;
using Microsoft.AspNetCore.Mvc;
namespace JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CrearUsuarioUseCase _useCase;

        public UsuarioController(CrearUsuarioUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }
        [HttpPost("Crear")]
        public IActionResult CrearUsuario([FromBody] CrearUsuarioRequest request)
        {
            if (request == null)
            {
                return BadRequest("La solicitud no puede ser null");
            }
            try
            {
                CrearUsuarioInput input = _mapper.Map<CrearUsuarioInput>(request);
                CrearUsuarioOutput output = _useCase.Execute(input);
                return Ok(output);
            }
            catch (ArgumentInputException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message +
                                           (ex.InnerException != null ? " | Detalles: " + ex.InnerException.Message : ""));
            }

        }
    }
}
