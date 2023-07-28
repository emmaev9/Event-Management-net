using Microsoft.EntityFrameworkCore;
using TicketMS.Exceptions;
using TicketMS.Models;

namespace TicketMS.Repositories.Implementation
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly SpringDbContext _context;

        public TicketCategoryRepository(SpringDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketCategory>> GetAllAsync()
        {
            var ticketCategories = await _context.TicketCategories.ToListAsync();
            return ticketCategories;
        }

        public IEnumerable<TicketCategory> GetAll()
        {
            var ticketCategories =  _context.TicketCategories.ToList();
            return ticketCategories;
        }

        public async Task<TicketCategory> GetByIdAsync(int id)
        {
            var ticketCategory =  await _context.TicketCategories.Where(e => e.TicketCategoryid == id).FirstOrDefaultAsync();
            return ticketCategory;
        }

        public TicketCategory GetById(int id)
        {
            var ticketCategory = _context.TicketCategories.Where(e => e.TicketCategoryid == id).FirstOrDefault();
            return ticketCategory;
        }
        public async Task<TicketCategory> GetByTicketCategoryIdAndEventIdAsync(int ticketCategoryId, int eventId)
        {
            var ticketCategory = await _context.TicketCategories.Where(e => e.TicketCategoryid == ticketCategoryId && e.Eventid == eventId).FirstOrDefaultAsync();
            return ticketCategory;
        }
    }
}
