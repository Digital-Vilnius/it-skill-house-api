using AutoMapper;
using ItSkillHouse.Contracts.Technology;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class TechnologyProfile : Profile
    {
        public TechnologyProfile()
        {
            CreateMap<AddTechnologyRequest, Technology>();
            CreateMap<ListTechnologiesRequest, TechnologiesFilter>();

            CreateMap<Technology, TechnologyDto>()
                .ForMember(
                    dest => dest.Count,
                    opt => opt.MapFrom(src => src.Contractors.Count)
                );
        }
    }
}