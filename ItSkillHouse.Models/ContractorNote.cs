using System;

namespace ItSkillHouse.Models
{
    public class ContractorNote : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        
        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}