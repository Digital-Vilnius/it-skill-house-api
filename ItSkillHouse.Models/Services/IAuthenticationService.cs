using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Authentication;

namespace ItSkillHouse.Models.Services
{
    public interface IAuthenticationService
    {
        Task<ResultResponse<Tokens>> GetLoggedUser();
    }
}