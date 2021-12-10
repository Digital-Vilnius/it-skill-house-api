using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Profession;

namespace ItSkillHouse.Models.Repositories
{
    public interface IProfessionRepository : IBaseRepository<Profession>
    {
        Task<List<Profession>> GetAsync(ProfessionsFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(ProfessionsFilter filter);
    }
}