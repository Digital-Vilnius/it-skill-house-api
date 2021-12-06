using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Technology;

namespace ItSkillHouse.Models.Services
{
    public interface ITechnologyService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddTechnologyRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditTechnologyRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id);
        Task DeleteAsync(Guid id);
    }
}