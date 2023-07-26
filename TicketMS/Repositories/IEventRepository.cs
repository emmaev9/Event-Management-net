using TicketMS.Models;

namespace TicketMS.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();

        Task<Event> GetById(int id);

        void Add(Event @event);

        void Update(Event @event);

        void Delete(Event @event);
    }
}
