using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Authentication;

namespace ItSkillHouse.Models.Services
{
    public interface IAuthenticationService
    {
        Task<ResultResponse<Tokens>> LoginAsync(LoginRequest request);
        Task<ResultResponse<Tokens>> RegisterAsync(RegisterRequest request);
        Task<ResultResponse<Tokens>> RefreshToken(RefreshTokenRequest request);
    }
}