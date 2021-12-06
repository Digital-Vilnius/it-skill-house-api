using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class ContractorRepository : BaseRepository<Contractor>, IContractorRepository
    {
        public ContractorRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<Contractor> FormatQuery(IQueryable<Contractor> query)
        {
            return query
                .Include(contractor => contractor.User)
                .Include(contractor => contractor.Recruiter)
                .ThenInclude(recruiter => recruiter.User)
                .Include(contractor => contractor.Technologies)
                .ThenInclude(technology => technology.Technology)
                .Include(contractor => contractor.Rates);
        }

        public async Task<List<Contractor>> GetAsync(ContractorsFilter filter, Sort sort, Paging paging)
        {
            IQueryable<Contractor> query = Context.Set<Contractor>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = ApplySort(query, sort);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync(ContractorsFilter filter)
        {
            IQueryable<Contractor> query = Context.Set<Contractor>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }

        private IQueryable<Contractor> ApplyFilter(IQueryable<Contractor> query, ContractorsFilter filter)
        {
            if (filter.Keyword != null)
            {
                query = query.Where(contractor => contractor.User.FirstName.Contains(filter.Keyword) 
                                                  || contractor.User.LastName.Contains(filter.Keyword) 
                                                  || contractor.User.Email.Contains(filter.Keyword) 
                                                  || contractor.User.Phone.Contains(filter.Keyword)
                                                  || contractor.Recruiter.User.FirstName.Contains(filter.Keyword) 
                                                  || contractor.Recruiter.User.LastName.Contains(filter.Keyword));
            }
            if (filter.RateFrom.HasValue) query = query.Where(contractor => contractor.ActiveRate.Amount >= filter.RateFrom.Value);
            if (filter.RateTo.HasValue) query = query.Where(contractor => contractor.ActiveRate.Amount <= filter.RateTo.Value);
            if (filter.AvailableFrom.HasValue) query = query.Where(contractor => contractor.AvailableFrom >= filter.AvailableFrom.Value);
            if (filter.AvailableTo.HasValue) query = query.Where(contractor => contractor.AvailableFrom <= filter.AvailableTo.Value);
            if (filter.IsPublic.HasValue) query = query.Where(contractor => contractor.IsPublic == filter.IsPublic.Value);
            if (filter.IsRemote.HasValue) query = query.Where(contractor => contractor.IsRemote == filter.IsRemote.Value);
            if (filter.IsAvailable.HasValue) query = query.Where(contractor => contractor.IsAvailable == filter.IsRemote.Value);
            if (filter.RecruitersIds.Count > 0) query = query.Where(contractor => filter.RecruitersIds.Contains(contractor.RecruiterId));
            return query;
        }

        private IQueryable<Contractor> ApplySort(IQueryable<Contractor> query, Sort sort)
        {
            switch (sort.SortBy)
            {
                case "availableFrom":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.AvailableFrom);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.AvailableFrom);
                    break;
                }
                case "isRemote":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.IsRemote);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.IsRemote);
                    break;
                }
                case "isPublic":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.IsPublic);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.IsPublic);
                    break;
                }
                case "rate":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.Rates.FirstOrDefault(rate => rate.DateFrom >= DateTime.UtcNow && rate.DateTo <= DateTime.UtcNow).Amount);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.Rates.FirstOrDefault(rate => rate.DateFrom >= DateTime.UtcNow && rate.DateTo <= DateTime.UtcNow).Amount);
                    break;
                }
                case "recruiter":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.Recruiter.User.FirstName + contractor.Recruiter.User.LastName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.Recruiter.User.FirstName + contractor.Recruiter.User.LastName);
                    break;
                }
                case "fullName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.User.FirstName + contractor.User.LastName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.User.FirstName + contractor.User.LastName);
                    break;
                }
                case "created":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.Created);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.Created);
                    break;
                }
                case "updated":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.Updated);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.Updated);
                    break;
                }
                case "firstName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.User.FirstName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.User.FirstName);
                    break;
                }
                case "email":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.User.Email);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.User.Email);
                    break;
                }
                case "lastName":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.User.LastName);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.User.LastName);
                    break;
                }
                case "location":
                {
                    if (sort.SortDirection == "asc") query = query.OrderBy(contractor => contractor.Location);
                    if (sort.SortDirection == "desc") query = query.OrderByDescending(contractor => contractor.Location);
                    break;
                }
            }

            return query;
        }
    }
}