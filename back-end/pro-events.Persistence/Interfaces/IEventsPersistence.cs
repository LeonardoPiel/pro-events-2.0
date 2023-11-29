using Microsoft.EntityFrameworkCore;
using pro_events.Domain;
using pro_events.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.IPersistence
{
    public interface IEventsPersistence
    {
        Task<PageList<Event>> GetAllEventsAsync(PageParameters pageParams, int userId, bool includeSpeakerDetail);
        Task<Event> GetEventById(int userId, int id, bool includeSpeakerDetail = false);
    }
}
