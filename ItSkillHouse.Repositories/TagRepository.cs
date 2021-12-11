using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(SqlContext context) : base(context)
        {
        }
        
        protected override IQueryable<Tag> FormatQuery(IQueryable<Tag> query)
        {
            return query.Include(tag => tag.Contractors);
        }

        public async Task<List<Tag>> GetAsync(TagsFilter filter, Sort sort, Paging paging)
        {
            IQueryable<Tag> query = Context.Set<Tag>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = ApplySort(query, sort);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync(TagsFilter filter)
        {
            IQueryable<Tag> query = Context.Set<Tag>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private static IQueryable<Tag> ApplyFilter(IQueryable<Tag> query, TagsFilter filter)
        {
            if (filter.Query != null) query = query.Where(tag => tag.Name.Contains(filter.Query));
            return query;
        }

        private static IQueryable<Tag> ApplySort(IQueryable<Tag> query, Sort sort)
        {
            switch (sort.SortBy)
            {
                case "created":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(tag => tag.Created);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(tag => tag.Created);
                    break;
                }
                case "updated":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(tag => tag.Updated);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(tag => tag.Updated);
                    break;
                }
                case "name":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(tag => tag.Name);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(tag => tag.Name);
                    break;
                }
                case "id":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(tag => tag.Id);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(tag => tag.Id);
                    break;
                }
                default:
                {
                    query = query.OrderByDescending(tag => tag.Contractors.Count).ThenBy(tag => tag.Name);
                    break;
                }
            }

            return query;
        }
    }
}