using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Event;

namespace ItSkillHouse.Models.Services
{
    public interface IEventService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddEventRequest request);
        Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditEventRequest request);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListEventsRequest request);
        Task<ResultResponse<TModel>> GetAsync<TModel>(int id);
        Task DeleteAsync(int id);
    }
}