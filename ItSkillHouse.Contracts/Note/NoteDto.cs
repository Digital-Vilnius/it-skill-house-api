using ItSkillHouse.Contracts.Contractor;

namespace ItSkillHouse.Contracts.Note
{
    public class NoteDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ContractorDto Contractor { get; set; }
    }
}