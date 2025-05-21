using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JoseCarlosAdmisión.Seguridad
{
    public class TokenJWT
    {
        public static string GenerarTokenJWT(int usuarioId, int rolId, JWT jwt)
        {
            if (jwt == null)
                throw new Exception("JWT configuration is null");
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt.ClaveSecreta)
                );
            var _signingCredentials = new SigningCredentials(
                _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            var _Claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UsuarioId", usuarioId.ToString()),
                new Claim(ClaimTypes.Role, rolId == 1 ? "Administrador" : "Usuario") //Se asigna el rol
            };

            //Payload
            var _Payload = new JwtPayload(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: _Claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(jwt.TimeoutMinutos)
                );
            var _Token = new JwtSecurityToken(_Header, _Payload);
            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
