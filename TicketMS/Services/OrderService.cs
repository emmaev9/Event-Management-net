using AutoMapper;
using TicketMS.Exceptions;
using TicketMS.Models;
using TicketMS.Models.DTO;
using TicketMS.Repositories;

namespace TicketMS.Services
{
    public class OrderService : IOrderService
    {

        public readonly IMapper _mapper;
        public readonly IOrderRepository _orderRepository;
        public readonly ITicketCategoryRepository _ticketCategoryRepository;
        public readonly ICustomerRepository _customerRepository;

        public OrderService(IMapper mapper, 
                            IOrderRepository orderRepository, 
                            ITicketCategoryRepository ticketCategoryRepository,
                            ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _customerRepository = customerRepository;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var orderEntity =  await _orderRepository.GetByIdAsync(id);
            if (orderEntity == null)
            {
               throw new EntityNotFoundException($"Order with ID {id} not found.");
               
            }
            await _orderRepository.DeleteAsync(orderEntity);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var ordersDto = orders.Select(e => _mapper.Map<OrderDTO>(e));
            return ordersDto;
        }

        public async Task<OrderDTO> GetOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order with ID {id} not found.");
            }
            var orderDto = _mapper.Map<OrderDTO>(order);
            return orderDto;
        }

        public async Task<Order> SaveOrderAsync(OrderAddDTO orderAddDTO)
        {
            Customer currentCustomer = await _customerRepository.GetByIdAsync(orderAddDTO.CustomerID);
            if (currentCustomer == null)
            {
                throw new EntityNotFoundException($"Customer with ID {orderAddDTO.CustomerID} not found.");
            }
            Order newOrder = new Order
            {
                Customer = currentCustomer,
                NumberOfTickets = orderAddDTO.NumberOfTickets,
                OrderAt = DateTime.Now.Date
            };
            TicketCategory ticketCategory = await _ticketCategoryRepository.GetByTicketCategoryIdAndEventIdAsync(orderAddDTO.TicketCategoryID, orderAddDTO.EventId);
       
            if (ticketCategory == null)
            {
                throw new InvalidFieldException("EventID or TicketCategoryID does not exist.");
            }

            if (orderAddDTO.NumberOfTickets <= 0)
            {
                throw new InvalidFieldException("Number of tickets must be greater than zero.");
            }
            float totalPrice = ticketCategory.Price * orderAddDTO.NumberOfTickets;
            newOrder.TotalPrice = totalPrice;
            newOrder.TicketCategory = ticketCategory;
            await _orderRepository.AddAsync(newOrder);
            return newOrder;
        }

        public async Task<Order> UpdateOrderAsync(OrderPatchDTO orderPatch)
        {
            Order orderEntity = await _orderRepository.GetByIdAsync(orderPatch.OrderID);
            if (orderEntity == null)
            {
                throw new EntityNotFoundException($"Order with ID {orderPatch.OrderID} not found.");
            }
            TicketCategory ticketCategory = await _ticketCategoryRepository.GetByIdAsync(orderPatch.TicketCategoryID);
            if (ticketCategory == null)
            {
                throw new InvalidFieldException($"TickerCategoryID {orderPatch.TicketCategoryID} does not exist.");
            }

            _mapper.Map(orderPatch, orderEntity);
            if (orderPatch.NumberOfTickets <= 0)
            {
                throw new InvalidFieldException("Number of tickets must be greater than zero.");
            }
            orderEntity.TotalPrice = ticketCategory.Price * orderPatch.NumberOfTickets;
            await _orderRepository.UpdateAsync(orderEntity);
            return orderEntity;
        }
    }
}
