using TicketMS.Models;

namespace TicketMS.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();

        Task<Event> GetByIdAsync(int id);

        Task AddAsync(Event @event);

        Task UpdateAsync(Event @event);

        Task DeleteAsync(Event @event);
    }
}
