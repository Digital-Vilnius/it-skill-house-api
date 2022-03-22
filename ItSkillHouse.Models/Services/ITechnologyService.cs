using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Technology;

namespace ItSkillHouse.Models.Services
{
    public interface ITechnologyService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(SaveTechnologyRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
    }
}