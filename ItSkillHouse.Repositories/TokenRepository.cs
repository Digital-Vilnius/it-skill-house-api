using System.Threading.Tasks;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;

namespace ItSkillHouse.Repositories
{
    public class TokenRepository : BaseRepository<Token>, ITokenRepository
    {
        public TokenRepository(SqlContext context) : base(context)
        {
        }

        public Task<Token> GetValidRefreshToken(string refreshToken)
        {
            return GetAsync(token => token.Value == refreshToken && token.IsValid);
        }
    }
}