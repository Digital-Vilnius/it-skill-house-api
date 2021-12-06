using ItSkillHouse.Contracts.User;

namespace ItSkillHouse.Contracts.Recruiter
{
    public class RecruiterDto : BaseDto
    {
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}