using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<ListRequest, Paging>();
            CreateMap<ListRequest, Sort>();
            CreateMap<BaseModel, BaseDto>();
        }
    }
}