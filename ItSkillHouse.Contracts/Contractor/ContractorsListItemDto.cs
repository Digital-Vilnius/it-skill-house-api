using System;
using System.Collections.Generic;
using ItSkillHouse.Contracts.Note;
using ItSkillHouse.Contracts.Recruiter;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Contracts.Technology;

namespace ItSkillHouse.Contracts.Contractor
{
    public class ContractorsListItemDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public bool IsRemote { get; set; }
        public bool IsPublic { get; set; }
        public DateTime AvailableFrom { get; set; }
        public decimal Rate { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
        public List<NotesListItemDto> Notes { get; set; }
        public List<TagDto> Tags { get; set; }
        public TechnologyDto MainTechnology { get; set; }
        public RecruitersListItemDto Recruiter { get; set; }
        public DateTime ExperienceSince { get; set; }
        public string LinkedInUrl { get; set; }
        public int CodaId { get; set; }
        public int CinodeId { get; set; }
    }
}