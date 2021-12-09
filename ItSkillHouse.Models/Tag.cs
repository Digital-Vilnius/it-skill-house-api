using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class Tag : BaseModel
    {
        public string Name { get; set; }
        public List<ContractorTag> Contractors { get; set; }
    }
}