using AutoMapper;
using ItSkillHouse.Contracts.Role;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AddRoleRequest, Role>();
            CreateMap<EditRoleRequest, Role>();
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RolesListItemDto>();
        }
    }
}