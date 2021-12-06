using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class Technology : BaseModel
    {
        public string Name { get; set; }
        
        public List<ContractorTechnology> TechnologyContractors { get; set; }
    }
}