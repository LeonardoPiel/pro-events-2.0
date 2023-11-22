using pro_events.Application.DTO.Events;
using pro_events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.IServices
{
    public interface IEventService
    {
        Task<bool> AddEvent(EventDto model);
        Task<bool> UpdateEvent(int id, EventDto model);
        Task<bool> DeleteEvent(int id);
        Task<EventDto> GetEventById(int id, bool includeSpeakerDetail = false);
        Task<EventDto[]> GetEvents(bool includeSpeakerDetail = false);
        Task<EventDto[]> GetEventsBySubject(string s, bool includeSpeakerDetail = false);
    }
}
