using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.User;

namespace ItSkillHouse.Models.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetAsync(UsersFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(UsersFilter filter);
    }
}