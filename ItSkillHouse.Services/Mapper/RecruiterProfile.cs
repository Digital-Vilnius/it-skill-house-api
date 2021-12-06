using AutoMapper;
using ItSkillHouse.Contracts.Recruiter;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class RecruiterProfile : Profile
    {
        public RecruiterProfile()
        {
            CreateMap<ListRecruitersRequest, RecruitersFilter>();
            CreateMap<AddRecruiterRequest, Recruiter>();
            CreateMap<EditRecruiterRequest, Recruiter>();
            
            CreateMap<Recruiter, RecruitersListItemDto>()
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
                );

            CreateMap<Recruiter, RecruiterDto>()
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
                );
        }
    }
}