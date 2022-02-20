using System.Threading.Tasks;
using ItSkillHouse.Contracts;

namespace ItSkillHouse.Models.Services
{
    public interface IUserService
    {
        Task<ListResponse<TModel>> GetAsync<TModel>();
    }
}