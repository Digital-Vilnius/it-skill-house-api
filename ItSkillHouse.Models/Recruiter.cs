using System;
using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class Recruiter : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public List<Contractor> Contractors { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}