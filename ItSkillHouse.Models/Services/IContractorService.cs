using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Contractor;

namespace ItSkillHouse.Models.Services
{
    public interface IContractorService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddContractorRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditContractorRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListContractorsRequest request);
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}