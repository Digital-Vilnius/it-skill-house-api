using AutoMapper;
using ItSkillHouse.Contracts.Authentication;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}