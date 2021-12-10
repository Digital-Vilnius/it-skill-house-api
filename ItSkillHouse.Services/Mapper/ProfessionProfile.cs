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
            CreateMap<Profession, ProfessionDto>();
            CreateMap<ListProfessionsRequest, ProfessionsFilter>();
        }
    }
}