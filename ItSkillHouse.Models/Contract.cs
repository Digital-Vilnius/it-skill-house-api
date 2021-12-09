using System;

namespace ItSkillHouse.Models
{
    public class Contract : BaseModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        public int RateId { get; set; }
        public Rate Rate { get; set; }
        
        public int ClientProjectId { get; set; }
        public ClientProject ClientProject { get; set; }
        
        public int RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }
    }
}