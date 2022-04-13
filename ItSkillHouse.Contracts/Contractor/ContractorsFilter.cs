using System;
using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Contractor
{
    public class ContractorsFilter
    {
        public string Keyword { get; set; }
        public List<int> RecruitersIds { get; set; }
        public List<int> TechnologiesIds { get; set; }
        public List<int> MainTechnologiesIds { get; set; }
        public List<int> ProfessionsIds { get; set; }
        public List<int> TagsIds { get; set; }
        public List<string> CountriesCodes { get; set; }
        public bool? HasContractor { get; set; }
        public bool? IsRemote { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsOnSite { get; set; }
        public decimal? RateTo { get; set; }
        public int? ExperienceFrom { get; set; }
        public DateTime? AvailableFrom { get; set; }
    }
}