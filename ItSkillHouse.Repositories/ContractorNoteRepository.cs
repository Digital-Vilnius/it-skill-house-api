using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;

namespace ItSkillHouse.Repositories
{
    public class ContractorNoteRepository : BaseRepository<ContractorNote>, IContractorNoteRepository
    {
        public ContractorNoteRepository(SqlContext context) : base(context)
        {
        }
    }
}