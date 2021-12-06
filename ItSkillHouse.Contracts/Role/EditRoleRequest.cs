using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Role
{
    public class EditRoleRequest
    {
        [Required]
        public string Name { get; set; }
        
        public List<string> Permissions { get; set; }
    }
}