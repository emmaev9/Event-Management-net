using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketMS.Exceptions;
using TicketMS.Models;
using TicketMS.Models.DTO;
using TicketMS.Repositories;

namespace TicketMS.Services
{
    public class EventService : IEventService
    {
        private readonly EventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(EventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDTO>> GetAllAsync()
        {
            var @events = await _eventRepository.GetAllAsync();
            var eventsDto = events.Select(e => _mapper.Map<EventDTO>(e));
            return eventsDto;
        }

        public async Task<EventDTO> GetByIdAsync(int id)
        {
            var @event = await _eventRepository.GetByIdAsync(id);
            if (@event == null)
            {
                throw new EntityNotFoundException($"Event with ID {id} not found.");
            }
            var eventDto = _mapper.Map<EventDTO>(@event);
            return eventDto;
            
        }

        public async Task<Event> UpdateAsync(EventPatchDTO eventPatch)
        {
            if (eventPatch == null) throw new ArgumentNullException(nameof(eventPatch));

            var eventEntity = await _eventRepository.GetByIdAsync(eventPatch.EventId);
            if (eventEntity == null)
            {
                throw new EntityNotFoundException($"Event with ID {eventPatch.EventId} not found.");
            }

            _mapper.Map(eventPatch, eventEntity);
            await _eventRepository.UpdateAsync(eventEntity);
            return eventEntity;
        }


        public async Task  DeleteAsync(int id)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(id);
            if (eventEntity == null)
            {
                throw new EntityNotFoundException($"Event with ID {id} not found.");
            }
            await _eventRepository.DeleteAsync(eventEntity);
        }

      
        public async Task<Event> AddAsync(EventAddDTO eventDTO)
        {
            var eventToSave = _mapper.Map<Event>(eventDTO);
            await _eventRepository.AddAsync(eventToSave);
            return eventToSave;
        }
    }
}

