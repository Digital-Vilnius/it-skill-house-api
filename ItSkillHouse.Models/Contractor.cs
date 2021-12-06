using System;
using System.Collections.Generic;
using System.Linq;

namespace ItSkillHouse.Models
{
    public class Contractor : BaseModel
    {
        public string Location { get; set; }
        
        public bool IsRemote { get; set; }
        
        public bool IsPublic { get; set; }
        
        public DateTime? AvailableFrom { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Guid RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }
        
        public List<ContractorTechnology> Technologies { get; set; }
        public List<ContractorNote> Notes { get; set; }
        public List<Rate> Rates { get; set; }
        public List<Contract> Contracts { get; set; }
        public Rate ActiveRate => Rates.FirstOrDefault(rate => rate.IsActive);
        public bool IsAvailable => AvailableFrom >= DateTime.UtcNow && AvailableFrom <= DateTime.UtcNow;
    }
}