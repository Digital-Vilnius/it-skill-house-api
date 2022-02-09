using System.Linq;
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
    }
}