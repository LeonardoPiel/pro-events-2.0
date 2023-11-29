using pro_events.Application.DTO.Events;
using pro_events.Domain;
using pro_events.Persistence.Helpers;
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
        Task<bool> DeleteEvent(int userId, int id);
        Task<EventDto> GetEventByIdAsync(int userId, int id, bool includeSpeakerDetail = false);
        Task<PageList<EventDto>> GetAllEventsAsync(PageParameters pageParams, int userId, bool includeSpeakerDetail = false);
    }
}
