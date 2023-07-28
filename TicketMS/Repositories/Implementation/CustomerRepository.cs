using Microsoft.EntityFrameworkCore;
using TicketMS.Exceptions;
using TicketMS.Models;

namespace TicketMS.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SpringDbContext _context;
        public CustomerRepository(SpringDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public async Task<Customer> GetByIdAsync(int id) {
            var customer = await _context.Customers.Where(e => e.Customerid == id).FirstOrDefaultAsync();
            return customer;
        }

        public Customer GetById(int id)
        { 
            var customer = _context.Customers.Where(e => e.Customerid == id).FirstOrDefault();
            return customer;
        }
    }
}
