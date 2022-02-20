using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Models
{
    public class Tag : BaseModel
    {
        [Required]
        public string Name { get; set; }
        
        public List<ContractorTag> Contractors { get; set; }
    }
}