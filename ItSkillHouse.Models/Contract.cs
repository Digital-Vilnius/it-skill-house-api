using System;

namespace ItSkillHouse.Models
{
    public class Contract : BaseModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        public Guid RateId { get; set; }
        public Rate Rate { get; set; }
        
        public Guid ClientProjectId { get; set; }
        public ClientProject ClientProject { get; set; }
        
        public Guid RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }
    }
}