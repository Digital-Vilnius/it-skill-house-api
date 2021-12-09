using System;

namespace ItSkillHouse.Models.Services
{
    public interface ITokenService
    {
        Token GenerateRefreshToken(int userId);
        
        Token GenerateRefreshToken();
        
        string GenerateToken(int id);
    }
}