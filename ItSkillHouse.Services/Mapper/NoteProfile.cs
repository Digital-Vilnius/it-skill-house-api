using AutoMapper;
using ItSkillHouse.Contracts.Note;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<SaveNoteRequest, Note>();
            CreateMap<ListNotesRequest, NotesFilter>();
            CreateMap<Note, NoteDto>();
        }
    }
}