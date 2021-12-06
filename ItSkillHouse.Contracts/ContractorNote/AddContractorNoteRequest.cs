using System;

namespace ItSkillHouse.Contracts.ContractorNote
{
    public class AddContractorNoteRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid ContractorId { get; set; }
    }
}