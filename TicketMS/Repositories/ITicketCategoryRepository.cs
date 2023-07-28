using TicketMS.Models;

namespace TicketMS.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task<IEnumerable<TicketCategory>> GetAllAsync();
        IEnumerable<TicketCategory> GetAll();
        Task<TicketCategory> GetByIdAsync(int id);
        TicketCategory GetById(int id);
        Task<TicketCategory> GetByTicketCategoryIdAndEventIdAsync(int ticketCategoryId, int eventId);
    }
}
