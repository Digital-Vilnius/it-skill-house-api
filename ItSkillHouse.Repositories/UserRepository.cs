using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.User;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAsync(UsersFilter filter, Sort sort, Paging paging)
        {
            IQueryable<User> query = Context.Set<User>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = ApplySort(query, sort);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync(UsersFilter filter)
        {
            IQueryable<User> query = Context.Set<User>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private IQueryable<User> ApplyFilter(IQueryable<User> query, UsersFilter filter)
        {
            if (filter.Keyword != null)
            {
                query = query.Where(user => user.FirstName.Contains(filter.Keyword) 
                                            || user.LastName.Contains(filter.Keyword) 
                                            || user.Email.Contains(filter.Keyword) 
                                            || user.Phone.Contains(filter.Keyword));
            }

            return query;
        }
        
        private IQueryable<User> ApplySort(IQueryable<User> query, Sort sort)
        {
            switch (sort.SortBy)
            {
                case "fullName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(user => user.FirstName + user.LastName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(user => user.FirstName + user.LastName);
                    break;
                }
                case "created":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(user => user.Created);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(user => user.Created);
                    break;
                }
                case "updated":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(user => user.Updated);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(user => user.Updated);
                    break;
                }
                case "firstName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(user => user.FirstName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(user => user.FirstName);
                    break;
                }
                case "email":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(user => user.Email);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(user => user.Email);
                    break;
                }
                case "lastName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(user => user.LastName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(user => user.LastName);
                    break;
                }
            }

            return query;
        }
    }
}