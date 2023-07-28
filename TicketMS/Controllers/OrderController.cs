using Microsoft.AspNetCore.Mvc;
using TicketMS.Models;
using TicketMS.Models.DTO;
using TicketMS.Services;

namespace TicketMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
             _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            IEnumerable<OrderDTO> allOrders = await _orderService.GetAllOrdersAsync();
            return Ok(allOrders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var orderDto = await _orderService.GetOrderAsync(id);
            return Ok(orderDto);
        }


        [HttpPatch]
        public async Task<ActionResult<OrderPatchDTO>> Patch(OrderPatchDTO orderPatch)
        {
            var updatedOrder = await _orderService.UpdateOrderAsync(orderPatch);
            return Ok(updatedOrder);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
           await _orderService.DeleteOrderAsync(id);
           return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(OrderAddDTO orderAddDTO)
        {
            Order orderSaved =  await _orderService.SaveOrderAsync(orderAddDTO);
            return CreatedAtAction(nameof(GetById), new { id = orderSaved.Orderid }, orderSaved);
   
        }
    }
}
