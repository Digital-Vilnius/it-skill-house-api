using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class Profession : BaseModel
    {
        public string Name { get; set; }
        
        public List<Contractor> Contractors { get; set; }
    }
}