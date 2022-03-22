using System.Linq;
using AutoMapper;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Models;
using ItSkillHouse.Services.Mapper.Resolvers;

namespace ItSkillHouse.Services.Mapper
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            CreateMap<ListContractorsRequest, ContractorsFilter>();

            CreateMap<SaveContractorRequest, Contractor>()
                .ForMember(
                    dest => dest.Technologies,
                    opt => opt.MapFrom<TechnologiesResolver>()
                )
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(src => src.TagsIds.Select(id => new ContractorTag {TagId = id}))
                );

            CreateMap<Contractor, ContractorDto>()
                .ForMember(
                    dest => dest.Technologies,
                    opt => opt.MapFrom(src =>
                        src.Technologies.Where(technology => technology.IsMain == false).ToList()
                            .Select(technology => technology.Technology))
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
                    dest => dest.MainTechnologies,
                    opt => opt.MapFrom(src => src.Technologies.Where(technology => technology.IsMain == true).ToList().Select(technology => technology.Technology))
                );
        }
    }
}