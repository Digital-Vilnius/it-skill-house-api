using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Role;

namespace ItSkillHouse.Models.Services
{
    public interface IRoleService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddRoleRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditRoleRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id);
        Task DeleteAsync(Guid id);
    }
}