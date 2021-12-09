using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Tag;

namespace ItSkillHouse.Models.Services
{
    public interface ITagService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddTagRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>();
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}