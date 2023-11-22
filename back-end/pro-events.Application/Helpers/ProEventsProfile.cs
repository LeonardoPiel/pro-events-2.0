using AutoMapper;
using pro_events.Application.DTO.Events;
using pro_events.Application.DTO.Social;
using pro_events.Application.DTO.Speakers;
using pro_events.Application.DTO.TicketLots;
using pro_events.Domain;

namespace pro_events.Application.Helpers
{
    public class ProEventsProfile : Profile
    {
        public ProEventsProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Speaker, SpeakerDto>().ReverseMap();
            CreateMap<Social, SocialDto>().ReverseMap();
            CreateMap<TicketLot, TicketLotDto>().ReverseMap();
        }
    }
}
