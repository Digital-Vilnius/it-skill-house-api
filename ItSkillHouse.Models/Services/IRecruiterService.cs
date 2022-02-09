using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Recruiter;

namespace ItSkillHouse.Models.Services
{
    public interface IRecruiterService
    {
        Task<ListResponse<TModel>> GetAsync<TModel>();
    }
}