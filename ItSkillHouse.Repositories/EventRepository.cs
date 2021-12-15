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
            query = ApplySort(query, sort);
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
            if (filter.Query != null) query = query.Where(e => e.Title.Contains(filter.Query));
            if (filter.ContractorId.HasValue) query = query.Where(e => e.ContractorId == filter.ContractorId.Value);
            if (filter.DateFrom.HasValue) query = query.Where(e => e.Date >= filter.DateFrom.Value);
            if (filter.DateTo.HasValue) query = query.Where(e => e.Date <= filter.DateTo.Value);
            return query;
        }
        
        private static IQueryable<Event> ApplySort(IQueryable<Event> query, Sort sort)
        {
            switch (sort.SortBy)
            {
                case "created":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(e => e.Created);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(e => e.Created);
                    break;
                }
                case "updated":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(e => e.Updated);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(e => e.Updated);
                    break;
                }
                case "title":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(e => e.Title);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(e => e.Title);
                    break;
                }
                case "date":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(e => e.Date);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(e => e.Date);
                    break;
                }
                case "id":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(e => e.Id);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(e => e.Id);
                    break;
                }
                default:
                {
                    query = query.OrderByDescending(e => e.Date).ThenBy(e => e.Title);
                    break;
                }
            }

            return query;
        }
    }
}