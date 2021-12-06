using ItSkillHouse.Contracts.User;

namespace ItSkillHouse.Contracts.Recruiter
{
    public class RecruitersListItemDto : BaseDto
    {
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}