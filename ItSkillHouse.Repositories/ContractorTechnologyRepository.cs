using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;

namespace ItSkillHouse.Repositories
{
    public class ContractorTechnologyRepository : BaseRepository<ContractorTechnology>, IContractorTechnologyRepository
    {
        public ContractorTechnologyRepository(SqlContext context) : base(context)
        {
        }
    }
}