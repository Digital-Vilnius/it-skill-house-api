using System;
using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Contractor
{
    public class AddContractorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AvailableFrom { get; set; }
        public List<Guid> TechnologiesIds { get; set; }
        public Guid MainTechnologyId { get; set; }
        public bool IsRemote { get; set; }
        public bool IsPublic { get; set; }
        public string Location { get; set; }
        public Guid RecruiterId { get; set; }
        public decimal Rate { get; set; }
    }
}