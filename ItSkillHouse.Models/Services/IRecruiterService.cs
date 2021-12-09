using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Recruiter;

namespace ItSkillHouse.Models.Services
{
    public interface IRecruiterService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddRecruiterRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditRecruiterRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListRecruitersRequest request);
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}