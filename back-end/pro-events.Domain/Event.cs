using pro_events.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_events.Domain
{
	public class Event
	{
		public int Id { get; set; }
		public string Location { get; set; }
		public DateTime EventDate { get; set; }
		public string Subject { get; set; }
		public int Amount { get; set; }
		public string? ImgUrl { get; set; }
		public string? Cellphone { get; set; }
		public string Email { get; set; }
		public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<TicketLot>? TicketLots { get; set; }
		public IEnumerable<Social>? Socials { get; set; }
		public IEnumerable<SpeakerEvent>? SpeakerEvents { get; set; }
	}
}