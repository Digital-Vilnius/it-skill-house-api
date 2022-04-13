using AutoMapper;
using ItSkillHouse.Contracts.Profession;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class ProfessionProfile : Profile
    {
        public ProfessionProfile()
        {
            CreateMap<SaveProfessionRequest, Profession>();
            CreateMap<Profession, ProfessionDto>();
        }
    }
}