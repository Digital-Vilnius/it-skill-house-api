using System;

namespace ItSkillHouse.Models
{
    public class ClientUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}