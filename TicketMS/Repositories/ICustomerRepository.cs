using TicketMS.Models;

namespace TicketMS.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        IEnumerable<Customer> GetAll();
        Task<Customer> GetByIdAsync(int id);
        Customer GetById(int id);
    }
}
