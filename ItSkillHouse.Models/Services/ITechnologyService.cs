using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Technology;

namespace ItSkillHouse.Models.Services
{
    public interface ITechnologyService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddTechnologyRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListTechnologiesRequest request);
        Task DeleteAsync(int id);
    }
}