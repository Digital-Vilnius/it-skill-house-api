using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Contract;

namespace ItSkillHouse.Models.Services
{
    public interface IContractService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddContractRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditContractRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id);
        Task DeleteAsync(Guid id);
    }
}