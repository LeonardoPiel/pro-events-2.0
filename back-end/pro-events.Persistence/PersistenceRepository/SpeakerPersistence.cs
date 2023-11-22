using Microsoft.EntityFrameworkCore;
using pro_events.API.Persistence;
using pro_events.Domain;
using pro_events.Persistence.IPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.Repository
{
    public class SpeakerPersistence : ProEventsPersistence, ISpeakerPersistence
    {
        public SpeakerPersistence(ProEventsContext context) : base(context) 
        {
        }
        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEventsDetail)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(e => e.Socials);
            query = includeEventsDetail ? query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Event) : query;
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string s, bool includeEventsDetail)
        {
            IQueryable<Speaker> query = _context.Speakers.Where(e => (e.Name + e.LastName).ToLower().Contains(s.ToLower()))
                .Include(e => e.Socials);
            query = includeEventsDetail ? query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Event) : query;
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Speaker> GetById(int id, bool includeEventsDetail)
        {
            IQueryable<Speaker> query = includeEventsDetail
                                        ? _context.Speakers.Where(s => s.Id == id).Include(e => e.SpeakerEvents).ThenInclude(se => se.Event)
                                        : _context.Speakers.Where(s => s.Id == id);

            query = query.OrderBy(e => e.Id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
