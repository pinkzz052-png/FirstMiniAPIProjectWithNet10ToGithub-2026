using System.Security.Claims;
using System.Text;
using CopyStackOverFlow_Version2.Services.IServices;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace CopyStackOverFlow_Version2.Services
{
        public class TokenJwtServices : ITokenJwtServices
        {
            private readonly IConfiguration _config;
            public TokenJwtServices(IConfiguration config)
            {
                _config = config;
            }
            public string GenerateNewJwtToken(Guid userId, string email)
            {
                var secretKey = Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]!);
                var securityKey = new SymmetricSecurityKey(secretKey);

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                var issuer = _config["JwtSettings:Issuer"];
                var audience = _config["JwtSettings:Audience"];
                var expires = DateTime.UtcNow.AddHours(2);

                var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials // Kết hợp Header + Payload + Key để sinh ra Signature
                );

                return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            }
        }
}

