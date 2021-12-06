using System.Collections.Generic;

namespace ItSkillHouse.Contracts.Role
{
    public class RolesListItemDto: BaseDto
    {
        public string Name { get; set; }
        
        public List<string> Permissions { get; set; }
    }
}