using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Technology;

namespace ItSkillHouse.Models.Repositories
{
    public interface ITechnologyRepository : IBaseRepository<Technology>
    {
        Task<List<Technology>> GetAsync(TechnologiesFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(TechnologiesFilter filter);
    }
}