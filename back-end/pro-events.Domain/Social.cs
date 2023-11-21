using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_events.Domain
{
	public class Social
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string URL { get; set; }
		public int? SpeakerId { get; set; }
		public Speaker Speaker { get; set; }
	}
}