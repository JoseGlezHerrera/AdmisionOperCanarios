using AutoMapper;
using JoseCarlos.Application.UseCases.Usuarios.LoginUsuario;
using JoseCarlosAdmisión.Seguridad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace JoseCarlosAdmisión.UsesCases.Usuarios.LoginUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly LoginUsuarioUseCase _useCase;
        private readonly IOptions<JWT> _jwt;
        private readonly IMapper _mapper;
        public UsuarioController(LoginUsuarioUseCase useCase, IMapper mapper, IOptions<JWT> jwt)
        {
            _useCase = useCase;
            _jwt = jwt;
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public IActionResult Login([Required] LoginUsuarioRequest request)
        {
            var input = this._mapper.Map<LoginUsuarioRequest, LoginUsuarioInput>(request);
            var output = this._useCase.Execute(input);
            var response = this._mapper.Map<LoginUsuarioOutput, LoginUsuarioResponse>(output);
            response.Token = TokenJWT.GenerarTokenJWT(output.UsuarioId,output.RolId,this._jwt.Value);
            return Ok(response);
        }
    }
}

