namespace ItSkillHouse.Contracts.Note
{
    public class AddNoteRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContractorId { get; set; }
    }
}