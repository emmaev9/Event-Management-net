using AutoMapper;
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
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> getAllOrders()
        {
            var orders = await _orderRepository.GetAll();

            var ordersDto = orders.Select(e => _mapper.Map<OrderDTO>(e));
            return Ok(ordersDto);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDTO>> getOrderById(int id)
        {
            var order = await _orderRepository.GetById(id);
            if(order == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderDTO>(order);
            return Ok(orderDto);
        }


        [HttpPatch]
        public async Task<ActionResult<OrderPatchDTO>> Patch(OrderPatchDTO orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderID);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}
