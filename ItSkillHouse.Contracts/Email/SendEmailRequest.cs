using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Email
{
    public class SendEmailRequest
    {
        public List<int> ContractorsIds { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}