using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ItSkillHouse.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        
        public TokenService(IConfiguration configuration)
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            _audience = configuration["Jwt:Audience"];
            _secret = configuration["Jwt:Secret"];
            _issuer = configuration["Jwt:Issuer"];
        }
        
        public string GenerateRefreshToken()
        {
            var randomHash = new byte[64];
            var cryptoServiceProvider = new RNGCryptoServiceProvider();
            cryptoServiceProvider.GetBytes(randomHash);
            return Convert.ToBase64String(randomHash);
        }

        public string GenerateToken(int id)
        {
            var claims = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, id.ToString()) });
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _issuer,
                Audience = _audience,
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentials
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }
    }
}