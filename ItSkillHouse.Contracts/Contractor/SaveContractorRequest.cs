#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Contractor
{
    public class SaveContractorRequest
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        
        public string? LinkedInUrl { get; set; }
        
        public int? CodaId { get; set; }
        public int? CinodeId { get; set; }
        
        [Required]
        public string CountryCode { get; set; }
        public string? City { get; set; }
        
        public decimal? Rate { get; set; }
        public string? Currency { get; set; }
        
        public DateTime? AvailableFrom { get; set; }
        public int? ExperienceSince { get; set; }

        public bool IsRemote { get; set; }
        public bool IsPublic { get; set; }
        public bool HasContract { get; set; }
        public bool IsOnSite { get; set; }
        
        public int? ProfessionId { get; set; }
        
        [Required]
        public int RecruiterId { get; set; }
        
        public List<int>? TagsIds { get; set; }
        public List<int>? TechnologiesIds { get; set; }
        public List<int> MainTechnologiesIds { get; set; }
    }
}