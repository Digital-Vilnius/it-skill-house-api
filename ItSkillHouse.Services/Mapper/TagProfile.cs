using AutoMapper;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class TagProfile: Profile
    {
        public TagProfile()
        {
            CreateMap<AddTagRequest, Tag>();
            CreateMap<Tag, TagDto>();
            CreateMap<ListTagsRequest, TagsFilter>();
        }
    }
}