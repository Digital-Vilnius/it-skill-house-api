using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Event;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(SqlContext context) : base(context)
        {
        }

        public async Task<List<Event>> GetAsync(EventsFilter filter, Sort sort, Paging paging)
        {
            IQueryable<Event> query = Context.Set<Event>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.OrderByDescending(model => model.Date);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync(EventsFilter filter)
        {
            IQueryable<Event> query = Context.Set<Event>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private static IQueryable<Event> ApplyFilter(IQueryable<Event> query, EventsFilter filter)
        {
            if (filter.Query != null) query = query.Where(model => model.Title.Contains(filter.Query));
            if (filter.ContractorId.HasValue) query = query.Where(model => model.ContractorId == filter.ContractorId.Value);
            if (filter.DateFrom.HasValue) query = query.Where(model => model.Date >= filter.DateFrom.Value);
            if (filter.DateTo.HasValue) query = query.Where(model => model.Date <= filter.DateTo.Value);
            return query;
        }
    }
}