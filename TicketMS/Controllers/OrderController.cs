using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMS.Models;
using TicketMS.Models.DTO;
using TicketMS.Repositories;

namespace TicketMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<Order>> getAllOrders()
        {
            var orders = _orderRepository.GetAll();

            var ordersDto = orders.Select(e => new OrderDTO()
            {
                OrderID = e.Orderid,
                CustomerID = e.Customerid ?? 0,
                NumberOfTickets = e.NumberOfTickets,
                TicketCategoryID = e.TicketCategoryid ?? 0,
                OrderAt = e.OrderAt,
                TotalPrice = e.TotalPrice,
    
            }) ;
            return Ok(ordersDto);
        }

        [HttpGet]
        public ActionResult<Order> getOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            if(order == null)
            {
                return NotFound();
            }

            OrderDTO orderDTO = new OrderDTO
            {
                OrderID = order.Orderid,
                CustomerID = order.Customerid ?? 0,
                TicketCategoryID = order.TicketCategoryid ?? 0,
                NumberOfTickets = order.NumberOfTickets,
                TotalPrice = order.TotalPrice,
                OrderAt = order.OrderAt
            };
            return Ok(orderDTO);
        }
    }
}
