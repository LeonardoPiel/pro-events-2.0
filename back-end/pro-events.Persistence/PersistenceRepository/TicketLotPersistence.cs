using Microsoft.EntityFrameworkCore;
using pro_events.API.Persistence;
using pro_events.Domain;
using pro_events.Persistence.IPersistence;
using pro_events.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.PersistenceRepository
{
    public class TicketLotPersistence : ProEventsPersistence, ITicketLotPersistence
    {
        public TicketLotPersistence(ProEventsContext context) : base(context)
        {
        }
        public async Task<TicketLot> GetTicketLotByIdsAsync(int ticketLotId, int eventId)
        {
            var query = await _context.TicketLots.SingleOrDefaultAsync(t => t.EventId == eventId && t.Id == ticketLotId);
            return query;
        }
        public async Task<TicketLot[]> GetTicketLotByEventIdAsync(int eventId)
        {
            IQueryable<TicketLot> query = _context.TicketLots.Where(t => t.EventId == eventId);
            query.OrderBy(t => t.Id);
            return await query.ToArrayAsync();
        }
    }
}
