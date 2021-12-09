using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Rate;

namespace ItSkillHouse.Models.Services
{
    public interface IRateService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddRateRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditRateRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}