using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Technology;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class TechnologyRepository : BaseRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(SqlContext context) : base(context)
        {
        }

        public async Task<List<Technology>> GetAsync(TechnologiesFilter filter, Sort sort, Paging paging)
        {
            IQueryable<Technology> query = Context.Set<Technology>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = ApplySort(query, sort);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }
        
        public async Task<int> CountAsync(TechnologiesFilter filter)
        {
            IQueryable<Technology> query = Context.Set<Technology>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private static IQueryable<Technology> ApplyFilter(IQueryable<Technology> query, TechnologiesFilter filter)
        {
            if (filter.Query != null) query = query.Where(technology => technology.Name.Contains(filter.Query));
            return query;
        }

        private static IQueryable<Technology> ApplySort(IQueryable<Technology> query, Sort sort)
        {
            switch (sort.SortBy)
            {
                case "created":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(technology => technology.Created);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(technology => technology.Created);
                    break;
                }
                case "updated":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(technology => technology.Updated);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(technology => technology.Updated);
                    break;
                }
                case "name":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(technology => technology.Name);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(technology => technology.Name);
                    break;
                }
                case "id":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(technology => technology.Id);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(technology => technology.Id);
                    break;
                }
                default:
                {
                    query = query.OrderByDescending(technology => technology.Name);
                    break;
                }
            }

            return query;
        }
    }
}