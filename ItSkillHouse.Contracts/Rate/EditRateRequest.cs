using System;

namespace ItSkillHouse.Contracts.Rate
{
    public class EditRateRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal Amount { get; set; }
        public int ContractorId { get; set; }
    }
}