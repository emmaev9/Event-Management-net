using TicketMS.Models;
using TicketMS.Models.DTO;

namespace TicketMS.Services
{
    public interface IEventService
    {

        Task<IEnumerable<EventDTO>> GetAllAsync();

        Task<EventDTO> GetByIdAsync(int id);

        Task<Event> UpdateAsync(EventPatchDTO eventPatch);

        Task DeleteAsync(int id);
    
        Task<Event> AddAsync(EventAddDTO eventDTO);
  
    }
}

