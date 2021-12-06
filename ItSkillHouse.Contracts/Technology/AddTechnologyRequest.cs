using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Technology
{
    public class AddTechnologyRequest
    {
        [Required]
        public string Name { get; set; }
    }
}