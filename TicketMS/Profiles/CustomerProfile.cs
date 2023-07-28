using AutoMapper;
using TicketMS.Models;
using TicketMS.Models.DTO;

namespace TicketMS.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
        }
    }
}
