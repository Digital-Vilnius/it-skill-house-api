using System;

namespace ItSkillHouse.Models
{
    public class ClientProject : BaseModel
    {
        public string Name { get; set; }
        
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Contract Contract { get; set; }
    }
}