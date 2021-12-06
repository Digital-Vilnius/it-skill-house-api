using AutoMapper;
using ItSkillHouse.Contracts.Client;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ListClientsRequest, ClientsFilter>();
            CreateMap<AddClientRequest, Client>();
            CreateMap<EditClientRequest, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<Client, ClientsListItemDto>();
        }
    }
}