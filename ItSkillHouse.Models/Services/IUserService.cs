using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.User;

namespace ItSkillHouse.Models.Services
{
    public interface IUserService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddUserRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditUserRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListUsersRequest request);
        Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id);
        Task DeleteAsync(Guid id);
    }
}