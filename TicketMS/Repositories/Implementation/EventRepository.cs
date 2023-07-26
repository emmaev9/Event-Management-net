using TicketMS.Models;

namespace TicketMS.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly SpringDbContext _dbContext;

        public EventRepository()
        {
            _dbContext = new SpringDbContext();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;
            return events;
        }

        public Event GetById(int id)
        {
            var @event = _dbContext.Events.Where(e => e.Eventid == id).FirstOrDefault();
            if (@event != null)
            {
                return @event;
            }
            return null;
           
        }

        public void Update(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
