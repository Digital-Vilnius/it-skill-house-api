using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Note;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(SqlContext context) : base(context)
        {
        }
        
        protected override IQueryable<Note> FormatQuery(IQueryable<Note> query)
        {
            return query.Include(note => note.CreatedBy);
        }

        public async Task<List<Note>> GetAsync(NotesFilter filter, Sort sort, Paging paging)
        {
            IQueryable<Note> query = Context.Set<Note>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.OrderByDescending(model => model.Created);
            query = ApplyPaging(query, paging);
            query = query.Where(model => model.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync(NotesFilter filter)
        {
            IQueryable<Note> query = Context.Set<Note>();
            query = FormatQuery(query);
            query = ApplyFilter(query, filter);
            query = query.Where(model => model.IsDeleted == false);
            return await query.CountAsync();
        }
        
        private static IQueryable<Note> ApplyFilter(IQueryable<Note> query, NotesFilter filter)
        {
            if (filter.ContractorId.HasValue) query = query.Where(model => model.ContractorId == filter.ContractorId.Value);
            return query;
        }
    }
}