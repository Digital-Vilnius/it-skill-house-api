using System;

namespace ItSkillHouse.Models
{
    public class ContractorTechnology : BaseModel
    {
        public string Level { get; set; }
        public bool IsMain { get; set; }
        
        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        public Guid TechnologyId { get; set; }
        public Technology Technology { get; set; }
    }
}