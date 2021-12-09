using System;
using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Contractor
{
    public class ListContractorsRequest : ListRequest
    {
        public string Keyword { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public List<int> RecruitersIds { get; set; }
        public List<int> TechnologiesIds { get; set; }
        public bool? IsRemote { get; set; }
        public bool? IsPublic { get; set; }
        public decimal? RateFrom { get; set; }
        public decimal? RateTo { get; set; }
    }
}