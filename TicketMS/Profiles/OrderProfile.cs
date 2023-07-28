using AutoMapper;
using TicketMS.Models;
using TicketMS.Models.DTO;

namespace TicketMS.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<OrderPatchDTO, Order>().ReverseMap();
            CreateMap<OrderAddDTO,Order>().ReverseMap();
        }

    }
}
