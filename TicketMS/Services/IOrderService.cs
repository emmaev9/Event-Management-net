using TicketMS.Models;
using TicketMS.Models.DTO;

namespace TicketMS.Services
{
    public interface IOrderService
    {
        Task<Order> SaveOrderAsync(OrderAddDTO order);
        Task DeleteOrderAsync(int id);
        Task<Order> UpdateOrderAsync(OrderPatchDTO order);
        Task<OrderDTO> GetOrderAsync(int id);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
    }
}
