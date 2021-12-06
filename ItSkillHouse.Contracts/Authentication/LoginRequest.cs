using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Authentication
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}