using System.ComponentModel.DataAnnotations;

namespace ItSkillHouse.Contracts.Note
{
    public class SaveNoteRequest
    {
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int ContractorId { get; set; }
    }
}