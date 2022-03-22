using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Profession
{
    public class SaveProfessionRequest
    {
        [Required]
        public string Name { get; set; }
    }
}