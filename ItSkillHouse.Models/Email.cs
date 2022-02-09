using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class Email : BaseModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        
        public int SenderId { get; set; }
        public User Sender { get; set; }
            
        public List<RecipientEmail> Recipients { get; set; }
    }
}