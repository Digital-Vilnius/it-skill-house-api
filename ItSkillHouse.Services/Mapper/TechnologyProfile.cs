﻿using AutoMapper;
using ItSkillHouse.Contracts.Technology;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class TechnologyProfile : Profile
    {
        public TechnologyProfile()
        {
            CreateMap<AddTechnologyRequest, Technology>();
            CreateMap<EditTechnologyRequest, Technology>();
            CreateMap<Technology, TechnologyDto>();
            CreateMap<Technology, TechnologiesListItemDto>();
        }
    }
}