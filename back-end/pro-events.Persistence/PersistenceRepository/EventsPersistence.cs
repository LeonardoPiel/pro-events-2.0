using Microsoft.EntityFrameworkCore;
using pro_events.API.Persistence;
using pro_events.Domain;
using pro_events.Persistence.IPersistence;
using pro_events.Persistence.Repository;

namespace pro_events.Persistence
{
    public class EventsPersistence : ProEventsPersistence, IEventsPersistence
    {
        public EventsPersistence(ProEventsContext context) : base(context) {}

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakerDetail)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.TicketLots)
                .Include(e => e.Socials);
            query = includeSpeakerDetail ? query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker) : query;
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsBySubjectAsync(string s, bool includeSpeakerDetail = false)
        {
            IQueryable<Event> query = _context.Events.Where(e => e.Subject.ToLower().Contains(s.ToLower()))
                .Include(e => e.TicketLots)
                .Include(e => e.Socials);
            query = includeSpeakerDetail ? query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker) : query;
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetById(int id, bool includeSpeakerDetail = false)
        {

            IQueryable<Event> query = _context.Events.Where(e => e.Id == id)
               .Include(e => e.TicketLots)
               .Include(e => e.Socials);
            query = includeSpeakerDetail ? query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker) : query;
            query = query.OrderBy(e => e.Id);
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
