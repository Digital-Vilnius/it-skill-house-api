using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Tag
{
    public class AddTagRequest
    {
        [Required]
        public string Name { get; set; }
    }
}