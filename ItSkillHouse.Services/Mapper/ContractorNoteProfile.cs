using AutoMapper;
using ItSkillHouse.Contracts.ContractorNote;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class ContractorNoteProfile : Profile
    {
        public ContractorNoteProfile()
        {
            CreateMap<AddContractorNoteRequest, ContractorNote>();
            CreateMap<EditContractorNoteRequest, ContractorNote>();
            CreateMap<ContractorNote, ContractorNoteDto>();
            CreateMap<ContractorNote, ContractorNotesListItemDto>();
        }
    }
}