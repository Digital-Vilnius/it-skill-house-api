using System;

namespace ItSkillHouse.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
    }
}