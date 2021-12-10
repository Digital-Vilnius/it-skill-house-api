using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Tag;

namespace ItSkillHouse.Models.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<List<Tag>> GetAsync(TagsFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(TagsFilter filter);
    }
}