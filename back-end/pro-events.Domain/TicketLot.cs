using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_events.Domain
{
	public class TicketLot
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public decimal Value { get; set; }
		public DateTime Init { get; set; }
		public DateTime End { get; set; }
		public int Amount { get; set; }
		public int EventId { get; set; }
		public Event Event { get; set; }
	}
}