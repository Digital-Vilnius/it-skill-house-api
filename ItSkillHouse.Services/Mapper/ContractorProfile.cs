using System.Linq;
using AutoMapper;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            CreateMap<ListContractorsRequest, ContractorsFilter>();
            CreateMap<AddContractorRequest, Contractor>();
            CreateMap<AddContractorRequest, User>();
            CreateMap<AddContractorRequest, Rate>()
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Rate)
                );
            
            CreateMap<EditContractorRequest, Contractor>();
            
            CreateMap<Contractor, ContractorDto>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.User.FirstName)
                )
                .ForMember(
                    dest => dest.Phone,
                    opt => opt.MapFrom(src => src.User.Phone)
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.User.LastName)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.User.Email)
                )
                .ForMember(
                    dest => dest.Technologies,
                    opt => opt.MapFrom(src => src.Technologies.Select(technology => technology.Technology))
                )
                .ForMember(
                    dest => dest.Rate,
                    opt => opt.MapFrom(src => src.ActiveRate.Amount)
                );
            
            CreateMap<Contractor, ContractorsListItemDto>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.User.FirstName)
                )
                .ForMember(
                    dest => dest.Phone,
                    opt => opt.MapFrom(src => src.User.Phone)
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.User.LastName)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.User.Email)
                )
                .ForMember(
                    dest => dest.Technologies,
                    opt => opt.MapFrom(src => src.Technologies.Select(technology => technology.Technology))
                )
                .ForMember(
                    dest => dest.Rate,
                    opt => opt.MapFrom(src => src.ActiveRate.Amount)
                );
        }
    }
}