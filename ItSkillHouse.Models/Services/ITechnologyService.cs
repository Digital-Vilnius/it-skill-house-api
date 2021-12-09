using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Technology;

namespace ItSkillHouse.Models.Services
{
    public interface ITechnologyService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddTechnologyRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}