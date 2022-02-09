namespace ItSkillHouse.Contracts.Note
{
    public class ListNotesRequest : ListRequest
    {
        public int? ContractorId { get; set; }
    }
}