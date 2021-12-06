using System;
using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Contractor
{
    public class ContractorsFilter : BaseFilter
    {
        public string Keyword { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public List<Guid> RecruitersIds { get; set; }
        public List<Guid> TechnologiesIds { get; set; }
        public bool? IsRemote { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? RateFrom { get; set; }
        public decimal? RateTo { get; set; }
    }
}