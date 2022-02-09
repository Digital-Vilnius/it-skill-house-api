namespace ItSkillHouse.Models
{
    public class RecipientEmail
    {
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        
        public int EmailId { get; set; }
        public Email Email { get; set; }
    }
}