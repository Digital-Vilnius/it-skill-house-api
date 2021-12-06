using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Recruiter;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class RecruiterRepository : BaseRepository<Recruiter>, IRecruiterRepository
    {
        public RecruiterRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<Recruiter> FormatQuery(IQueryable<Recruiter> query)
        {
            return query.Include(recruiter => recruiter.User);
        }

        public async Task<List<Recruiter>> GetAsync(RecruitersFilter filter = null, Sort sort = null, Paging paging = null)
        {
            IQueryable<Recruiter> query = Context.Set<Recruiter>();
            query = FormatQuery(query);
            if (filter != null) query = ApplyFilter(query, filter);
            if (sort != null) query = ApplySort(query, sort);;
            if (paging != null) query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync(RecruitersFilter filter)
        {
            IQueryable<Recruiter> query = Context.Set<Recruiter>();
            query = FormatQuery(query);
            if (filter != null) query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private IQueryable<Recruiter> ApplyFilter(IQueryable<Recruiter> query, RecruitersFilter filter)
        {
            if (filter.Keyword != null)
            {
                query = query.Where(recruiter => recruiter.User.FirstName.Contains(filter.Keyword) 
                                                 || recruiter.User.LastName.Contains(filter.Keyword) 
                                                 || recruiter.User.Email.Contains(filter.Keyword) 
                                                 || recruiter.User.Phone.Contains(filter.Keyword));
            }

            return query;
        }
        
        private IQueryable<Recruiter> ApplySort(IQueryable<Recruiter> query, Sort sort)
        {
            switch (sort.SortBy)
            {
                case "fullName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(recruiter => recruiter.User.FirstName + recruiter.User.LastName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(recruiter => recruiter.User.FirstName + recruiter.User.LastName);
                    break;
                }
                case "created":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(recruiter => recruiter.User.Created);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(recruiter => recruiter.User.Created);
                    break;
                }
                case "updated":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(recruiter => recruiter.User.Updated);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(recruiter => recruiter.User.Updated);
                    break;
                }
                case "firstName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(recruiter => recruiter.User.FirstName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(recruiter => recruiter.User.FirstName);
                    break;
                }
                case "email":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(recruiter => recruiter.User.Email);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(recruiter => recruiter.User.Email);
                    break;
                }
                case "lastName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(recruiter => recruiter.User.LastName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(recruiter => recruiter.User.LastName);
                    break;
                }
            }

            return query;
        }
    }
}