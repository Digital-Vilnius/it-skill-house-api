using System;

namespace ItSkillHouse.Contracts.Contract
{
    public class AddContractRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid ContractorId { get; set; }
        public Guid RateId { get; set; }
        public Guid ClientProjectId { get; set; }
        public Guid RecruiterId { get; set; }
    }
}