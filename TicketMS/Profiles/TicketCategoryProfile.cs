using AutoMapper;
using TicketMS.Models;
using TicketMS.Models.DTO;

namespace TicketMS.Profiles
{
    public class TicketCategoryProfile : Profile
    {
        public TicketCategoryProfile()
        {
            CreateMap<TicketCategoryDTO, TicketCategory>().ReverseMap();
        }
    }
}
