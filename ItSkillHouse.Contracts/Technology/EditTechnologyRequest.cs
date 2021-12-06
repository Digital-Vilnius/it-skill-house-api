using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Technology
{
    public class EditTechnologyRequest
    {
        [Required]
        public string Name { get; set; }
    }
}