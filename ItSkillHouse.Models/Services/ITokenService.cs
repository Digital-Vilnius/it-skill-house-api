using System;

namespace ItSkillHouse.Models.Services
{
    public interface ITokenService
    {
        Token GenerateRefreshToken(Guid userId);
        
        Token GenerateRefreshToken();
        
        string GenerateToken(Guid id);
    }
}