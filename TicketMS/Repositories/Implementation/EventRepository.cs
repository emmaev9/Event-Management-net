using Microsoft.EntityFrameworkCore;
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

        public void Add(Event @event)
        {
            _dbContext.Add(@event);
            _dbContext.SaveChanges();
        }

        public void Delete(Event @event)
        {
                _dbContext.Remove(@event);
                _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var events = await _dbContext.Events.ToListAsync();
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events.Where(e => e.Eventid == id).FirstOrDefaultAsync();
            return @event;
           
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
