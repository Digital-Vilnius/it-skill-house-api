using System.Linq;
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
                
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.Roles,
                    opt => opt.MapFrom(src => src.UserRoles.Select(userRole => userRole.Role))
                );
            
            CreateMap<User, UsersListItemDto>()
                .ForMember(
                    dest => dest.Roles,
                    opt => opt.MapFrom(src => src.UserRoles.Select(userRole => userRole.Role))
                );
        }
    }
}