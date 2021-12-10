using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Profession;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class ProfessionRepository : BaseRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(SqlContext context) : base(context)
        {
        }

        public async Task<List<Profession>> GetAsync(ProfessionsFilter filter, Sort sort, Paging paging)
        {
            IQueryable<Profession> query = Context.Set<Profession>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = ApplySort(query, sort);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }
        
        public async Task<int> CountAsync(ProfessionsFilter filter)
        {
            IQueryable<Profession> query = Context.Set<Profession>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private static IQueryable<Profession> ApplyFilter(IQueryable<Profession> query, ProfessionsFilter filter)
        {
            if (filter.Query != null) query = query.Where(profession => profession.Name.Contains(filter.Query));
            return query;
        }

        private static IQueryable<Profession> ApplySort(IQueryable<Profession> query, Sort sort)
        {
            switch (sort.SortBy)
            {
                case "created":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(profession => profession.Created);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(profession => profession.Created);
                    break;
                }
                case "updated":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(profession => profession.Updated);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(profession => profession.Updated);
                    break;
                }
                case "name":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(profession => profession.Name);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(profession => profession.Name);
                    break;
                }
                case "id":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(profession => profession.Id);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(profession => profession.Id);
                    break;
                }
                default:
                {
                    query = query.OrderByDescending(profession => profession.Name);
                    break;
                }
            }

            return query;
        }
    }
}