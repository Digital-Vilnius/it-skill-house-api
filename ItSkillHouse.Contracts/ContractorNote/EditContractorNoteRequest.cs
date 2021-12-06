using System;

namespace ItSkillHouse.Contracts.ContractorNote
{
    public class EditContractorNoteRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid ContractorId { get; set; }
    }
}