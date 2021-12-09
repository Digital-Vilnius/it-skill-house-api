using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.ClientProject;

namespace ItSkillHouse.Models.Services
{
    public interface IClientProjectService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddClientProjectRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditClientProjectRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}