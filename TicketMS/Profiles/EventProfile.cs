using AutoMapper;
using TicketMS.Models;
using TicketMS.Models.DTO;

namespace TicketMS.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDTO, Event>().ReverseMap();
            CreateMap<EventPatchDTO, Event>().ReverseMap();
            CreateMap<EventAddDTO,Event>().ReverseMap();
        }
    }
}
