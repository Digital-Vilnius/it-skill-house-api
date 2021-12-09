using System;
using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Contractor
{
    public class EditContractorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<int> TechnologiesIds { get; set; }
        public bool IsRemote { get; set; }
        public string Location { get; set; }
        public int RecruiterId { get; set; }
        public decimal Rate { get; set; }
    }
}