using System;
using System.Collections.Generic;
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

            CreateMap<AddContractorRequest, Contractor>()
                .ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(src => new User {Email = src.Email, FirstName = src.FirstName, LastName = src.LastName, Created = DateTime.Now})
                )
                .ForMember(
                    dest => dest.Notes,
                    opt => opt.MapFrom(src => new List<Note> {new() {Content = src.Note, Created = DateTime.Now}})
                );

            CreateMap<EditContractorRequest, Contractor>()
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
                    dest => dest.LastEmail,
                    opt => opt.MapFrom(src =>
                        src.User.ReceivedEmails.Select(receivedEmail => receivedEmail.Email)
                            .OrderByDescending(email => email.Created).FirstOrDefault())
                )
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId)
                )
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