using AutoMapper;
using ItSkillHouse.Contracts.Event;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<SaveEventRequest, Event>();
            CreateMap<ListEventsRequest, EventsFilter>();
            CreateMap<Event, EventDto>();
        }
    }
}