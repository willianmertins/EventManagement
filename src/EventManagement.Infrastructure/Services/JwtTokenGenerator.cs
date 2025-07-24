using EventManagement.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EventManagement.Infrastructure.Services
{
    public class JwtTokenGenerator(IConfiguration configuration) : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration = configuration;

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["issuer"],
                audience: jwtSettings["audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
