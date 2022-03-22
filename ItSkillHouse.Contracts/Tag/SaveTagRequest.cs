using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Tag
{
    public class SaveTagRequest
    {
        [Required]
        public string Name { get; set; }
    }
}