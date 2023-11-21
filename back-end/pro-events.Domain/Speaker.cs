using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_events.Domain
{
	public class Speaker
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string? ImgUrl { get; set; }
		public string? Description { get; set; }
		public IEnumerable<Social>? Socials { get; set; }
		public IEnumerable<SpeakerEvent>? SpeakerEvents { get; set; }

	}
}