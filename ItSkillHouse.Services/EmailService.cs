using System.Linq;
using System.Threading.Tasks;
using ItSkillHouse.Contracts.Email;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;
using Microsoft.Graph;

namespace ItSkillHouse.Services
{
    public class EmailService : IEmailService
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly IContractorRepository _contractorRepository;
        
        public EmailService(IContractorRepository contractorRepository, GraphServiceClient graphServiceClient)
        {
            _contractorRepository = contractorRepository;
            _graphServiceClient = graphServiceClient;
        }

        public async Task SendEmail(SendEmailRequest request)
        {
            var user = await _graphServiceClient.Me.Request().GetAsync();

            var contractors = await _contractorRepository.GetByIdsAsync(request.ContractorsIds);
            
            var recipients = contractors.Select(contractor => new Recipient
            {
                EmailAddress = new EmailAddress { Address = contractor.Email }
            });

            var message = new Message
            {
                Subject = request.Subject,
                Body = new ItemBody { ContentType = BodyType.Html, Content = request.Body },
                ToRecipients = recipients,
            };

            await _graphServiceClient.Me
                .SendMail(message, true)
                .Request()
                .PostAsync();
        }
    }
}