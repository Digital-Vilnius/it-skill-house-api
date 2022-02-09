using System.Linq;
using AutoMapper;
using ItSkillHouse.Contracts.Email;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<ListEmailsRequest, EmailsFilter>();
            
            CreateMap<AddEmailRequest, Email>()
                .ForMember(
                    dest => dest.Recipients,
                    opt => opt.MapFrom(src => src.RecipientsIds.Select(id => new RecipientEmail {RecipientId = id}))
                );

            CreateMap<Email, EmailDto>()
                .ForMember(
                    dest => dest.Recipients,
                    opt => opt.MapFrom(src => src.Recipients.Select(recipient => recipient.Recipient))
                );
        }
    }
}