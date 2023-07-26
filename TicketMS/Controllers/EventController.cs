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


        public EventController(IEventRepository eventRepository)
        {
            //     _dbContext = new TicketsDbContext();
            _eventRepository = eventRepository;
       
        }

        [HttpGet]
        public ActionResult<List<EventDTO>> GetAll()
        {
            var events = _eventRepository.GetAll();

            var eventsDto = events.Select(e => new EventDTO()
            {
                EventId = e.Eventid,
                EventName = e.EventName,
                EventDescription = e.EventDescription ?? string.Empty,
                EventType = e.EventType?.Name ?? string.Empty,
                Venue = e.Venue?.Location ?? string.Empty
            });
            return Ok(eventsDto);
        }

        [HttpGet]
        public ActionResult<EventDTO> GetById(int id)
        {
            var @event = _eventRepository.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            var dtoEvent = new EventDTO
            {
                EventId = @event.Eventid,
                EventDescription = @event.EventDescription,
                EventName = @event.EventName,
                EventType = @event.EventType.Name ?? string.Empty,
                Venue = @event.Venue?.Location ?? string.Empty
            };

            return Ok(dtoEvent);
        }
    }

}
//Data Source=DESKTOP-7K2NNPM; Initial Catalog=tickets_db; Persist Security Info=True; User ID=sa; Password=***********
  //  Scaffold-DbContext "Data Source=DESKTOP-7K2NNPM;Initial Catalog=tickets_db;Integrated Security=True;TrustServerCertificate=True;encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models