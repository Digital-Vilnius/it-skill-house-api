using System.Collections.Generic;

namespace ItSkillHouse.Models
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        
        public List<ClientProject> ClientProjects { get; set; }
        public List<ClientUser> ClientUsers { get; set; }
    }
}