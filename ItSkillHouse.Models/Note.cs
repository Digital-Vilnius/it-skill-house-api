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
        
        [Required]
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }
}