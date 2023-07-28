using Microsoft.EntityFrameworkCore;
using TicketMS.Models;

namespace TicketMS.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SpringDbContext _dbContext;

        public OrderRepository(SpringDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(Order order)
        {
            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();

        }
        public void Add(Order order)
        {
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(Order order)
        {
            _dbContext.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _dbContext.Orders.Where(o => o.Orderid == id).FirstOrDefaultAsync();
            return order;

        }

        public async Task UpdateAsync(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
