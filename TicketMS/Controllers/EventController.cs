using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMS.Exceptions;
using TicketMS.Models;
using TicketMS.Models.DTO;
using TicketMS.Repositories;
using TicketMS.Services;

namespace TicketMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
     

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDTO>>> GetAll()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet]
        public async Task<ActionResult<EventDTO>> GetById(int id)
        {
            var @event = await _eventService.GetByIdAsync(id);
            return Ok(@event);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDTO>> Update(EventPatchDTO eventPatch)
        {
            var @event = await _eventService.UpdateAsync(eventPatch);
            return Ok(@event);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _eventService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EventAddDTO>> Add(EventAddDTO eventDTO)
        {
            Event eventToSave = await _eventService.AddAsync(eventDTO);
            return CreatedAtAction(nameof(GetById), new { id = eventToSave.Eventid }, eventToSave);
        }
    }
}  
//  Scaffold-DbContext "Data Source=DESKTOP-7K2NNPM;Initial Catalog=tickets_db;Integrated Security=True;TrustServerCertificate=True;encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models