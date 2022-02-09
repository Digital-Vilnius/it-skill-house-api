using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Email;

namespace ItSkillHouse.Models.Repositories
{
    public interface IEmailRepository : IBaseRepository<Email>
    {
        Task<List<Email>> GetAsync(EmailsFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(EmailsFilter filter);
    }
}