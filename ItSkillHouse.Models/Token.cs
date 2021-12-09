using System;

namespace ItSkillHouse.Models
{
    public class Token : BaseModel
    {
        public string Value { get; set; }
        public DateTime Expires { get; set; }
        public DateTime? Revoked { get; set; }
        public string Type { get; set; }
     
        public int UserId { get; set; }
        public User User { get; set; }

        public bool IsValid => Revoked == null && Expires < DateTime.UtcNow;
    }
}