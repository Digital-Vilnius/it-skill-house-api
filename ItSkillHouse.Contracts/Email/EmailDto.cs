using System.Collections.Generic;
using ItSkillHouse.Contracts.User;

namespace ItSkillHouse.Contracts.Email
{
    public class EmailDto : BaseDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<UserDto> Recipients { get; set; }
        public UserDto Sender { get; set; }
    }
}