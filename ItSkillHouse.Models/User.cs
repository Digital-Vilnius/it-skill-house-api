using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Models
{
    public class User : BaseModel
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public List<Contractor> Contractors { get; set; }
    }
}