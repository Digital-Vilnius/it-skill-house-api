using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Email
{
    public class AddEmailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<int> RecipientsIds { get; set; }
    }
}