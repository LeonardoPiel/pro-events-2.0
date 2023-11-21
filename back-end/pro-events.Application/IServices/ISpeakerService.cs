using pro_events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.IServices
{
    public interface ISpeakerService
    {
        Task<bool> AddSpeaker(Speaker model);
        Task<bool> UpdateSpeaker(int id, Speaker model);
        Task<bool> DeleteSpeaker(int id);
        Task<Speaker> GetSpeakerById(int id, bool includeDetail);
        Task<Speaker[]> GetSpeakers(bool includeDetail);
        Task<Speaker[]> GetSpeakersByName(string name, bool includeDetail);
    }
}
