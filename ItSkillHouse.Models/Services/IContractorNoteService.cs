using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.ContractorNote;

namespace ItSkillHouse.Models.Services
{
    public interface IContractorNoteService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddContractorNoteRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditContractorNoteRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id);
        Task DeleteAsync(Guid id);
    }
}