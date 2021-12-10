using System;
using System.Collections.Generic;
using System.Linq;

namespace ItSkillHouse.Models
{
    public class Contractor : BaseModel
    {
        public string LinkedInUrl { get; set; }
        public string Location { get; set; }
        public int? CodaId { get; set; }
        public int? CinodeId { get; set; }

        public bool IsOnSite { get; set; }
        public bool IsRemote { get; set; }
        public bool IsPublic { get; set; }
        public bool HasContract { get; set; }
        
        public DateTime AvailableFrom { get; set; }
        public DateTime ExperienceSince { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        
        public int RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }
        
        public List<ContractorTag> Tags { get; set; }
        public List<ContractorTechnology> Technologies { get; set; }
        public List<Note> Notes { get; set; }
        public List<Rate> Rates { get; set; }

        public Rate ActiveRate => Rates.ToList().FirstOrDefault(rate => rate.IsActive);
        public bool IsAvailable => AvailableFrom <= DateTime.UtcNow;
    }
}