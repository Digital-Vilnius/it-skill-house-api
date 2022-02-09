using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Authentication;
using ItSkillHouse.Contracts.Email;

namespace ItSkillHouse.Models.Services
{
    public interface IEmailService
    {
        Task<ResultResponse<TModel>> AddAsync<TModel>(AddEmailRequest request, LoggedUserDto loggedUser);
        Task<ListResponse<TModel>> GetAsync<TModel>(ListEmailsRequest request);
    }
}