using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Note;

namespace ItSkillHouse.Models.Repositories
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<List<Note>> GetAsync(NotesFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(NotesFilter filter);
    }
}