using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMS.Models;
using TicketMS.Models.DTO;
using TicketMS.Repositories;

namespace TicketMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
       
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDTO>>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            var eventsDto = events.Select(e => _mapper.Map<EventDTO>(e));
            return Ok(eventsDto);
        }

        [HttpGet]
        public async Task<ActionResult<EventDTO>> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }
    
            var eventDto = _mapper.Map<EventDTO>(@event);
            return Ok(eventDto);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDTO>> Patch(EventPatchDTO eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if(eventEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(eventPatch, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            Console.WriteLine("delete");
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<EventAddDTO> Add(EventAddDTO eventDTO)
        {
            Event eventToSave = new Event();
            eventToSave.Eventid = 7; 
            //TO DO: Modify DB to have auto-incrment on primary keys
            _mapper.Map(eventDTO,eventToSave);
            _eventRepository.Add(eventToSave);
            return NoContent();
        }
    }



}  
//  Scaffold-DbContext "Data Source=DESKTOP-7K2NNPM;Initial Catalog=tickets_db;Integrated Security=True;TrustServerCertificate=True;encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models