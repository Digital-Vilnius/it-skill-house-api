using System.Linq;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class ClientProjectRepository : BaseRepository<ClientProject>, IClientProjectRepository
    {
        public ClientProjectRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<ClientProject> FormatQuery(IQueryable<ClientProject> query)
        {
            return query
                .Include(clientProject => clientProject.Client)
                .Include(clientProject => clientProject.Contract).ThenInclude(contract => contract.Contractor)
                .ThenInclude(contractor => contractor.User)
                .Include(clientProject => clientProject.Contract).ThenInclude(contract => contract.Recruiter)
                .ThenInclude(recruiter => recruiter.User)
                .Include(clientProject => clientProject.Contract).ThenInclude(contract => contract.Rate);
        }
    }
}