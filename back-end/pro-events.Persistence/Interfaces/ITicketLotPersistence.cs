using pro_events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.IPersistence
{
    public interface ITicketLotPersistence
    {
        Task<TicketLot[]> GetTicketLotByEventIdAsync(int eventId);
        Task<TicketLot> GetTicketLotByIdsAsync(int ticketLotId, int eventId);

    }
}
