using System.Threading.Tasks;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;

namespace ItSkillHouse.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _context;
        
        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}