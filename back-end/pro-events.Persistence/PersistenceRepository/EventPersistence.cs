using Microsoft.EntityFrameworkCore;
using pro_events.API.Persistence;
using pro_events.Domain;
using pro_events.Persistence.Helpers;
using pro_events.Persistence.IPersistence;
using pro_events.Persistence.Repository;

namespace pro_events.Persistence
{
    public class EventPersistence : DefaultPersistence, IEventsPersistence
    {
        public EventPersistence(ProEventsContext context) : base(context) 
        {
        }

        public async Task<PageList<Event>> GetAllEventsAsync(PageParameters pageParams, int userId, bool includeSpeakerDetail)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.TicketLots)
                .Include(e => e.Socials);
            query = includeSpeakerDetail ? query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker) : query;
            query = query.OrderBy(e => e.Id).Where(e => e.UserId == userId && e.Subject.ToLower().Contains(pageParams.Term.ToLower()));
            return await PageList<Event>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public async Task<Event> GetEventById(int userId, int id, bool includeSpeakerDetail = false)
        {

            IQueryable<Event> query = _context.Events.Where(e => e.Id == id && e.UserId == userId)
               .Include(e => e.TicketLots)
               .Include(e => e.Socials);
            query = includeSpeakerDetail ? query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker) : query;
            query = query.OrderBy(e => e.Id);
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
