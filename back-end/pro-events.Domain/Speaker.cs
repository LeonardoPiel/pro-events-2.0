using pro_events.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_events.Domain
{
	public class Speaker
	{
		public int Id { get; set; }
		public string Cv { get; set; }
		public string? Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Social>? Socials { get; set; }
		public IEnumerable<SpeakerEvent>? SpeakerEvents { get; set; }

	}
}