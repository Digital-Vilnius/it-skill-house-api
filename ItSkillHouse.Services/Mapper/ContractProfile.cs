using AutoMapper;
using ItSkillHouse.Contracts.Contract;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<AddContractRequest, Contract>();
            CreateMap<EditContractRequest, Contract>();
            CreateMap<Contract, ContractDto>();
            CreateMap<Contract, ContractsListItemDto>();
        }
    }
}