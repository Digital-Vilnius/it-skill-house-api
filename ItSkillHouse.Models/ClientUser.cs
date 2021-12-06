using System;

namespace ItSkillHouse.Models
{
    public class ClientUser
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}