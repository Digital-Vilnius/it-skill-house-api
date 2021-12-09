namespace ItSkillHouse.Contracts.Note
{
    public class EditNoteRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContractorId { get; set; }
    }
}