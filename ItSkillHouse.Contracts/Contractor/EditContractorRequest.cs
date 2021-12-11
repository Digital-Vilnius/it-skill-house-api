using System;
using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Contractor
{
    public class EditContractorRequest
    {
        public string Location { get; set; }
        public decimal Rate { get; set; }
        
        public int ProfessionId { get; set; }
        public int RecruiterId { get; set; }
        public int MainTechnologyId { get; set; }
        
        public List<int> TechnologiesIds { get; set; }
        public List<int> TagsIds { get; set; }

        public DateTime ExperienceSince { get; set; }
        public DateTime AvailableFrom { get; set; }

        public string LinkedInUrl { get; set; }
        public int CodaId { get; set; }
        public int CinodeId { get; set; }

        public bool IsRemote { get; set; }
        public bool IsPublic { get; set; }
        public bool HasContract { get; set; }
        public bool IsOnSite { get; set; }
    }
}