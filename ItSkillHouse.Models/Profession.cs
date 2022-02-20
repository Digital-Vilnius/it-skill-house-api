using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Models
{
    public class Profession : BaseModel
    {
        [Required]
        public string Name { get; set; }
        
        public List<Contractor> Contractors { get; set; }
    }
}