using ItSkillHouse.Contracts.Contractor;

namespace ItSkillHouse.Contracts.ContractorNote
{
    public class ContractorNoteDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ContractorDto Contractor { get; set; }
    }
}