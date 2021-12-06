using AutoMapper;
using ItSkillHouse.Contracts.ClientProject;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class ClientProjectProfile : Profile
    {
        public ClientProjectProfile()
        {
            CreateMap<AddClientProjectRequest, ClientProject>();
            CreateMap<EditClientProjectRequest, ClientProject>();
            CreateMap<ClientProject, ClientProjectDto>();
            CreateMap<ClientProject, ClientProjectsListItemDto>();
        }
    }
}