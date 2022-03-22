using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Event;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(SaveEventRequest request)
        {
            var e = _mapper.Map<SaveEventRequest, Event>(request);
            await _eventRepository.AddAsync(e);
            await _unitOfWork.SaveChangesAsync();
            
            var eventDto = _mapper.Map<Event, TModel>(e);
            return new ResultResponse<TModel>(eventDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(int id, SaveEventRequest request)
        {
            var e = await _eventRepository.GetByIdAsync(id);
            if (e == null) throw new Exception("Event is not found");

            e = _mapper.Map(request, e);
            _eventRepository.Update(e);
            await _unitOfWork.SaveChangesAsync();
            
            var eventDto = _mapper.Map<Event, TModel>(e);
            return new ResultResponse<TModel>(eventDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>(ListEventsRequest request)
        {
            var filter = _mapper.Map<ListEventsRequest, EventsFilter>(request);
            var sort = _mapper.Map<ListEventsRequest, Sort>(request);
            var paging = _mapper.Map<ListEventsRequest, Paging>(request);
            
            var events = await _eventRepository.GetAsync(filter, sort, paging);
            var eventsCount = await _eventRepository.CountAsync(filter);

            var eventsDtosList = _mapper.Map<List<Event>, List<TModel>>(events);
            return new ListResponse<TModel>(eventsDtosList, eventsCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(int id)
        {
            var e = await _eventRepository.GetByIdAsync(id);
            if (e == null) throw new Exception("Event is not found");

            var eventDto = _mapper.Map<Event, TModel>(e);
            return new ResultResponse<TModel>(eventDto);
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _eventRepository.GetByIdAsync(id);
            if (e == null) throw new Exception("Event is not found");

            _eventRepository.Delete(e);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}