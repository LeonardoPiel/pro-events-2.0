using pro_events.Application.DTO.Events;
using pro_events.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.DTO.TicketLots
{
    public class TicketLotDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Init { get; set; }
        public DateTime End { get; set; }
        public int Amount { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}
