using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
        
        public List<UserRole> RoleUsers { get; set; }
    }
}