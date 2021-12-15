using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Event;

namespace ItSkillHouse.Models.Repositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<List<Event>> GetAsync(EventsFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(EventsFilter filter);
    }
}