using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Rate { get; set; }
        public string Currency { get; set; }
        
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
        public List<Event> Events { get; set; }

        public bool IsAvailable => AvailableFrom <= DateTime.UtcNow;

        public Event NearestEvent => Events.Where(e => e.Date >= DateTime.UtcNow).OrderByDescending(e => e.Date).FirstOrDefault();
    }
}