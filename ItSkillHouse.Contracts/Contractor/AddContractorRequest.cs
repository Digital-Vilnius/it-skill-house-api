namespace ItSkillHouse.Contracts.Contractor
{
    public class AddContractorRequest : EditContractorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public string Note { get; set; }
    }
}