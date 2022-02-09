using AutoMapper;
using ItSkillHouse.Contracts.User;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}