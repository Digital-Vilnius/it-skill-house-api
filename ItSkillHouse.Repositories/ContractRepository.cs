using System.Linq;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(SqlContext context) : base(context)
        {
        }

        protected override IQueryable<Contract> FormatQuery(IQueryable<Contract> query)
        {
            return query
                .Include(contract => contract.Contractor).ThenInclude(contractor => contractor.User)
                .Include(contract => contract.Recruiter).ThenInclude(recruiter => recruiter.User)
                .Include(contract => contract.ClientProject).ThenInclude(clientProject => clientProject.Client)
                .Include(contract => contract.Rate);
        }
    }
}