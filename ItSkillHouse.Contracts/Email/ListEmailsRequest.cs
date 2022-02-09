namespace ItSkillHouse.Contracts.Email
{
    public class ListEmailsRequest : ListRequest
    {
        public int? ContractorId { get; set; }
    }
}