using System;
using ItSkillHouse.Contracts.Contractor;

namespace ItSkillHouse.Contracts.Rate
{
    public class RateDto : BaseDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal Amount { get; set; }
        public ContractorDto Contractor { get; set; }
    }
}