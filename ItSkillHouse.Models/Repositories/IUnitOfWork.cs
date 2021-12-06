using System.Threading.Tasks;

namespace ItSkillHouse.Models.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}