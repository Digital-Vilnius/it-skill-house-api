using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Models
{
    public class ContractorTechnology : BaseModel
    {
        public string Level { get; set; }
        public bool IsMain { get; set; }
        
        [Required]
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        [Required]
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
    }
}