using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.DTO.TicketLots
{
    public class TicketLotDeleteDto
    {
        [Required]
        public int eventId { get; set; }
        [Required]
        public int ticketLotId { get; set; }
    }
}
