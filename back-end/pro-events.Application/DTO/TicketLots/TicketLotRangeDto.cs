using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.DTO.TicketLots
{
    public class TicketLotRangeDto
    {
        public int eventId { get; set; }
        public int[] ticketLotsIds { get; set; }
    }
}
