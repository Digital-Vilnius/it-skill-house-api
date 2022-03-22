using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Note;

namespace ItSkillHouse.Models.Services
{
    public interface INoteService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(SaveNoteRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(int id, SaveNoteRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListNotesRequest request);
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}