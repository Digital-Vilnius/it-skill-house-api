using System.Threading.Tasks;

namespace ItSkillHouse.Models.Repositories
{
    public interface ITokenRepository : IBaseRepository<Token>
    {
        Task<Token> GetValidRefreshToken(string refreshToken);
    }
}