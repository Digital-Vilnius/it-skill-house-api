using System;

namespace ItSkillHouse.Models
{
    public class Note : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}