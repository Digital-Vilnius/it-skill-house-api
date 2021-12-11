using AutoMapper;
using ItSkillHouse.Contracts.Profession;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class ProfessionProfile : Profile
    {
        public ProfessionProfile()
        {
            CreateMap<AddProfessionRequest, Profession>();
            CreateMap<ListProfessionsRequest, ProfessionsFilter>();
            
            CreateMap<Profession, ProfessionDto>()
                .ForMember(
                    dest => dest.Count,
                    opt => opt.MapFrom(src => src.Contractors.Count)
                );
        }
    }
}