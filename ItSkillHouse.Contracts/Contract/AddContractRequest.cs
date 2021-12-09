using System;

namespace ItSkillHouse.Contracts.Contract
{
    public class AddContractRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ContractorId { get; set; }
        public int RateId { get; set; }
        public int ClientProjectId { get; set; }
        public int RecruiterId { get; set; }
    }
}