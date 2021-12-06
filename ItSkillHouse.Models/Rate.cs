using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItSkillHouse.Models
{
    public class Rate : BaseModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
     
        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        public List<Contract> Contracts { get; set; }
        
        public bool IsActive => DateFrom >= DateTime.UtcNow && DateTo <= DateTime.UtcNow;
    }
}