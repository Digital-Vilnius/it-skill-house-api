using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Authentication
{
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}