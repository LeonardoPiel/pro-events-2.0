using Microsoft.EntityFrameworkCore;
using pro_events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.IPersistence
{
    public interface IEventsPersistence
    {
        Task<Event[]> GetAllEventsBySubjectAsync(string s, bool includeSpeakerDetail);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakerDetail);

        Task<Event> GetById(int id, bool includeSpeakerDetail = false);
    }
}
