using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Email;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class EmailRepository : BaseRepository<Email>, IEmailRepository
    {
        public EmailRepository(SqlContext context) : base(context)
        {
        }
        
        protected override IQueryable<Email> FormatQuery(IQueryable<Email> query)
        {
            return query
                .Include(email => email.Recipients)
                .ThenInclude(recipient => recipient.Recipient)
                .Include(email => email.Sender);
        }

        public async Task<List<Email>> GetAsync(EmailsFilter filter, Sort sort, Paging paging)
        {
            IQueryable<Email> query = Context.Set<Email>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.OrderByDescending(model => model.Created);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync(EmailsFilter filter)
        {
            IQueryable<Email> query = Context.Set<Email>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private static IQueryable<Email> ApplyFilter(IQueryable<Email> query, EmailsFilter filter)
        {
            if (filter.ContractorId.HasValue) query = query.Where(model => model.Recipients.Select(recipient => recipient.RecipientId).Contains(filter.ContractorId.Value));
            return query;
        }
    }
}