using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Technology
{
    public class SaveTechnologyRequest
    {
        [Required]
        public string Name { get; set; }
    }
}