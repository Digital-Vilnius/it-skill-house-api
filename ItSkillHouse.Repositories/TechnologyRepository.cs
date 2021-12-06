using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;

namespace ItSkillHouse.Repositories
{
    public class TechnologyRepository : BaseRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(SqlContext context) : base(context)
        {
        }
    }
}