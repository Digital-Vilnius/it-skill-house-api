using System;
using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class User : BaseModel
    {
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime? LastLoginDate { get; set; }
        
        public Contractor Contractor { get; set; }
        public Recruiter Recruiter { get; set; }
        public List<Token> Tokens { get; set; }
    }
}