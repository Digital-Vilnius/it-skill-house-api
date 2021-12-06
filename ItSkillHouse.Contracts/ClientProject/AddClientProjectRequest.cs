using System;

namespace ItSkillHouse.Contracts.ClientProject
{
    public class AddClientProjectRequest
    {
        public string Name { get; set; }
        
        public Guid ClientId { get; set; }
    }
}