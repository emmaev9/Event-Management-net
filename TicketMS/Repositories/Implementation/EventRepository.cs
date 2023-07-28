using Microsoft.EntityFrameworkCore;
using TicketMS.Exceptions;
using TicketMS.Models;

namespace TicketMS.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly SpringDbContext _dbContext;

        public EventRepository(SpringDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Event @event)
        {
            _dbContext.Add(@event);
             await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Event @event)
        {
                _dbContext.Remove(@event);
                await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var events = await _dbContext.Events.ToListAsync();
            return events;
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var @event = await _dbContext.Events.Where(e => e.Eventid == id).FirstOrDefaultAsync();
            if(@event == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }
            return @event;
        }

        public async Task UpdateAsync(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
             await _dbContext.SaveChangesAsync();
        }
    }
}
