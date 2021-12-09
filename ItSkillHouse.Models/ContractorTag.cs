namespace ItSkillHouse.Models
{
    public class ContractorTag
    {
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}