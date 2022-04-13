using System;
using System.Collections.Generic;
using ItSkillHouse.Contracts.Event;
using ItSkillHouse.Contracts.Note;
using ItSkillHouse.Contracts.Profession;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Contracts.Technology;
using ItSkillHouse.Contracts.User;

namespace ItSkillHouse.Contracts.Contractor
{
    public class ContractorDto : BaseDto
    {
        public string LinkedInUrl { get; set; }
        
        public int? CodaId { get; set; }
        public int? CinodeId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public string CountryCode { get; set; }
        public string City { get; set; }

        public decimal? Rate { get; set; }
        public string Currency { get; set; }

        public int? ExperienceSince { get; set; }
        public DateTime? AvailableFrom { get; set; }
        
        public bool IsAvailable { get; set; }
        public bool IsRemote { get; set; }
        public bool IsPublic { get; set; }
        public bool HasContract { get; set; }
        public bool IsOnSite { get; set; }
        
        public EventDto NearestEvent { get; set; }
        public ProfessionDto Profession { get; set; }
        public UserDto Recruiter { get; set; }
        public NoteDto LastNote { get; set; }
        
        public List<TagDto> Tags { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
        public List<TechnologyDto> MainTechnologies { get; set; }
    }
}