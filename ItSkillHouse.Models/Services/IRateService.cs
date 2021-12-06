using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Rate;

namespace ItSkillHouse.Models.Services
{
    public interface IRateService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddRateRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditRateRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id);
        Task DeleteAsync(Guid id);
    }
}