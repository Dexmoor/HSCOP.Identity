using HSCOP.Identity.Service.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace HSCOP.Identity.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly JWTSettings _jwtSettings;

        public AuthenticateService(IOptionsMonitor<JWTSettings> jwtSettingsOptions) {
            _jwtSettings = jwtSettingsOptions.CurrentValue;
        }

        public string GetJWTToken()
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Admin"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.ClientAppId,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(7)),
                signingCredentials: credentials,
                claims: claims
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
