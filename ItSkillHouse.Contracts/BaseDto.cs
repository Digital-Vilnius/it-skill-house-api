using System;

namespace ItSkillHouse.Contracts
{
    public class BaseDto
    {
        public int Id { get; set; }
        
        public DateTime? Updated { get; set; }
        
        public DateTime Created { get; set; }
    }
}