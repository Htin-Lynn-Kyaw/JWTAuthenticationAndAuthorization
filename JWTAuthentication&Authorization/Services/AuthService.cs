using JWTAuthentication_Authorization.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication_Authorization.Services
{
    public class AuthService
    {
        public string GenerateToken(ApplicationUser user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthSettings.Key);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);

        }

        private ClaimsIdentity GenerateClaims(ApplicationUser user)
        {
            var claims = new ClaimsIdentity();
            //claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));

            return claims;
        }
    }
}
