using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Models
{
    public class Note : BaseModel
    {
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}