using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_events.API.Models
{
	public class Events
	{
		public int Id { get; set; }
		public string? Location { get; set; }
		public DateTime? EventDate { get; set; }
		public string? Subject { get; set; }
		public int Amount { get; set; }
		public string? Number { get; set; }
		public string? ImgUrl { get; set; }
	}
}