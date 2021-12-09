using AutoMapper;
using ItSkillHouse.Contracts.Note;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddNoteRequest, Note>();
            CreateMap<EditNoteRequest, Note>();
            CreateMap<Note, NoteDto>();
            CreateMap<Note, NotesListItemDto>();
        }
    }
}