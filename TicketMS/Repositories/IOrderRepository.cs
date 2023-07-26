using TicketMS.Models;

namespace TicketMS.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();

        Task<Order> GetById(int id);

        int Add(Order order);

        void Update(Order order);

        void Delete(Order order);
    }
}
