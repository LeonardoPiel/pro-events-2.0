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
        Task<bool> AddEvent(Event model);
        Task<bool> UpdateEvent(int id, Event model);
        Task<bool> DeleteEvent(int id);
        Task<Event> GetEventById(int id, bool includeSpeakerDetail = false);
        Task<Event[]> GetEvents(bool includeSpeakerDetail = false);
        Task<Event[]> GetEventsBySubject(string s, bool includeSpeakerDetail = false);
    }
}
