using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pro_events.Domain;

namespace pro_events.API.Persistence
{
	public class ProEventsContext : DbContext
	{
		public ProEventsContext(DbContextOptions<ProEventsContext> options) : base(options) { }
		public DbSet<Event> Events { get; set; }
		public DbSet<Speaker> Speakers { get; set; }
		public DbSet<Social> Socials { get; set; }
		public DbSet<TicketLot> TicketLots { get; set; }
		public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SpeakerEvent>()
			.HasKey(SE => new { SE.EventId, SE.SpeakerId });

			modelBuilder.Entity<Event>()
				.HasMany(e => e.Socials)
				.WithOne(e => e.Event)
				.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(e => e.Socials)
                .WithOne(e => e.Speaker)
                .OnDelete(DeleteBehavior.Cascade);

        }

	}
}