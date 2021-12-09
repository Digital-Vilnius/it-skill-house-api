using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Client;

namespace ItSkillHouse.Models.Services
{
    public interface IClientService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddClientRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditClientRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}