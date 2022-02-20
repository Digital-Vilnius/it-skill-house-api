using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ItSkillHouse.Models
{
    public class Contractor : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string CountryCode { get; set; }
        
        public string Phone { get; set; }
        public string City { get; set; }
        
        public int? CodaId { get; set; }
        public int? CinodeId { get; set; }
        
        public string LinkedInUrl { get; set; }
        
        public bool IsOnSite { get; set; }
        public bool IsRemote { get; set; }
        public bool IsPublic { get; set; }
        public bool HasContract { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Rate { get; set; }
        public string Currency { get; set; }
        
        public DateTime? AvailableFrom { get; set; }
        public DateTime? ExperienceSince { get; set; }

        public int? ProfessionId { get; set; }
        public Profession Profession { get; set; }
        
        [Required]
        public int RecruiterId { get; set; }
        public User Recruiter { get; set; }
        
        public List<ContractorTag> Tags { get; set; }
        public List<ContractorTechnology> Technologies { get; set; }
        public List<Note> Notes { get; set; }
        public List<Event> Events { get; set; }

        public bool? IsAvailable => AvailableFrom != null && AvailableFrom.Value <= DateTime.UtcNow;
        public Event NearestEvent => Events.Where(e => e.Date >= DateTime.UtcNow).OrderByDescending(e => e.Date).FirstOrDefault();
    }
}