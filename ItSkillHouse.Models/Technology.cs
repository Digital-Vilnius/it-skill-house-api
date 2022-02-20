using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Models
{
    public class Technology : BaseModel
    {
        [Required]
        public string Name { get; set; }
        
        public List<ContractorTechnology> Contractors { get; set; }
    }
}