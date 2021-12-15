using System;
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
            CreateMap<AddContractorRequest, Contractor>()
                .ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(src => new User {Email = src.Email, Phone = src.Phone, FirstName = src.FirstName, LastName = src.LastName})
                )
                .ForMember(
                    dest => dest.Technologies,
                    opt => opt.MapFrom(src => src.TechnologiesIds.Select(id => new ContractorTechnology {TechnologyId = id}))
                )
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(src => src.TagsIds.Select(id => new ContractorTag {TagId = id}))
                );
            
            CreateMap<EditContractorRequest, Contractor>()
                .ForMember(
                    dest => dest.Technologies,
                    opt => opt.MapFrom(src => src.TechnologiesIds.Select(id => new ContractorTechnology {TechnologyId = id}))
                )
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(src => src.TagsIds.Select(id => new ContractorTag {TagId = id}))
                );

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
                    opt => opt.MapFrom(src => src.Technologies.Where(technology => technology.IsMain == false).ToList().Select(technology => technology.Technology))
                )
                .ForMember(
                    dest => dest.NearestEvent,
                    opt => opt.MapFrom(src => src.NearestEvent)
                )
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(src => src.Tags.Select(tag => tag.Tag))
                )
                .ForMember(
                    dest => dest.MainTechnology,
                    opt => opt.MapFrom(src => src.Technologies.FirstOrDefault(technology => technology.IsMain).Technology)
                );
        }
    }
}