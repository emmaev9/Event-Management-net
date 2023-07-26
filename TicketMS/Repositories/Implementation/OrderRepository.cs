using TicketMS.Models;

namespace TicketMS.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SpringDbContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new SpringDbContext();
        }

        public int Add(Order @event)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }

        public Order GetById(int id)
        {
            var orders = _dbContext.Orders;
            var order = orders.Where(o => o.Orderid == id).FirstOrDefault();
            if(order == null)
            {
                return null;
            }
            return order;

        }

        public void Update(Order @event)
        {
            throw new NotImplementedException();
        }
    }
}
