using Microsoft.EntityFrameworkCore;
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

        public void Delete(Order order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _dbContext.Orders.Where(o => o.Orderid == id).FirstOrDefaultAsync();
            return order;

        }

        public void Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
