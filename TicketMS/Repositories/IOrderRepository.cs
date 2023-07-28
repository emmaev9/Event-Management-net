using TicketMS.Models;

namespace TicketMS.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();

        Task<Order> GetByIdAsync(int id);

        Task AddAsync(Order order);
        void Add(Order order);  

        Task UpdateAsync(Order order);

        Task DeleteAsync(Order order);
    }
}
