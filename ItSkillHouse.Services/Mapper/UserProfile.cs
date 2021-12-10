using AutoMapper;
using ItSkillHouse.Contracts.User;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ListUsersRequest, UsersFilter>();
            CreateMap<AddUserRequest, User>();
            CreateMap<EditUserRequest, User>();
            CreateMap<User, UserDto>();
            CreateMap<User, UsersListItemDto>();
        }
    }
}