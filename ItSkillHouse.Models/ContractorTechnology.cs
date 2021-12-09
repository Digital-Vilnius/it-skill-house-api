using System;

namespace ItSkillHouse.Models
{
    public class ContractorTechnology : BaseModel
    {
        public string Level { get; set; }
        public bool IsMain { get; set; }
        
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
    }
}