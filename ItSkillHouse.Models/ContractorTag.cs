using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Models
{
    public class ContractorTag
    {
        [Required]
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        [Required]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}