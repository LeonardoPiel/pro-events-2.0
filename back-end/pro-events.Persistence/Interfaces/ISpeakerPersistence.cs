using pro_events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.IPersistence
{
    public interface ISpeakerPersistence
    {
        Task<Speaker[]> GetAllSpeakersByNameAsync(string s, bool includeEventsDetail = false);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEventsDetail = false);
        Task<Speaker> GetById(int id, bool includeEventsDetail = false);
    }
}
