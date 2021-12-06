using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Authentication
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}