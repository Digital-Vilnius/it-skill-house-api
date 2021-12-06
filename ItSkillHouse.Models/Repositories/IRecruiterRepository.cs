using System.Collections.Generic;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Recruiter;

namespace ItSkillHouse.Models.Repositories
{
    public interface IRecruiterRepository : IBaseRepository<Recruiter>
    {
        Task<List<Recruiter>> GetAsync(RecruitersFilter filter, Sort sort, Paging paging);
        Task<int> CountAsync(RecruitersFilter filter);
    }
}