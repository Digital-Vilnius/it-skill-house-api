using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Contractor;

namespace ItSkillHouse.Models.Repositories
{
    public interface IContractorRepository : IBaseRepository<Contractor>
    {
        Task<List<Contractor>> GetAsync(ContractorsFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(ContractorsFilter filter);
    }
}