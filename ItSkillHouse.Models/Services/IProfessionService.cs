using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Profession;

namespace ItSkillHouse.Models.Services
{
    public interface IProfessionService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(SaveProfessionRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
    }
}