using System.Threading.Tasks;

namespace ItSkillHouse.Models.Services;

public interface IAuthService
{
    Task<User> GetCurrentUserAsync();
}