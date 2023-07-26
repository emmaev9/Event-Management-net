using TicketMS.Models;

namespace TicketMS.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order GetById(int id);

        int Add(Order @event);

        void Update(Order @event);

        int Delete(int id);
    }
}
