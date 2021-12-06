using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.User
{
    public class EditUserRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}