using System.Threading.Tasks;
using ItSkillHouse.Contracts.Email;

namespace ItSkillHouse.Models.Services
{
    public interface IEmailService
    {
        Task SendEmail(SendEmailRequest request);
    }
}