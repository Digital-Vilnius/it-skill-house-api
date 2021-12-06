using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Contractor;

namespace ItSkillHouse.Models.Services
{
    public interface IContractorService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddContractorRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditContractorRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListContractorsRequest request);
        Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id);
        Task DeleteAsync(Guid id);
    }
}