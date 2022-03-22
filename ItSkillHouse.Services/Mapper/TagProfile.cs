using AutoMapper;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class TagProfile: Profile
    {
        public TagProfile()
        {
            CreateMap<SaveTagRequest, Tag>();
            
            CreateMap<Tag, TagDto>()
                .ForMember(
                    dest => dest.Count,
                    opt => opt.MapFrom(src => src.Contractors.Count)
                );
        }
    }
}