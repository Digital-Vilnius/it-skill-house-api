using ItSkillHouse.Contracts.User;

namespace ItSkillHouse.Contracts.Note
{
    public class NoteDto : BaseDto
    {
        public string Content { get; set; }
        
        public UserDto CreatedBy { get; set; }
    }
}