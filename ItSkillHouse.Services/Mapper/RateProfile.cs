using AutoMapper;
using ItSkillHouse.Contracts.Contract;
using ItSkillHouse.Contracts.Rate;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateMap<AddRateRequest, Rate>();
            CreateMap<EditRateRequest, Rate>();
            CreateMap<Rate, RateDto>();
            CreateMap<Rate, RatesListItemDto>();
        }
    }
}