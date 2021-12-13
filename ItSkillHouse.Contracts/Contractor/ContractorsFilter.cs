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
        
        public bool? HasContractor { get; set; }
        public bool? IsRemote { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsOnSite { get; set; }
        
        public decimal? RateFrom { get; set; }
        public decimal? RateTo { get; set; }
        
        public DateTime? ExperienceFrom { get; set; }
        public DateTime? ExperienceTo { get; set; }
        
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
    }
}