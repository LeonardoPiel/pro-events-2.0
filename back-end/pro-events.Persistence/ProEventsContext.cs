using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pro_events.Domain;
using pro_events.Domain.Identity;

namespace pro_events.API.Persistence
{
	public class ProEventsContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, 
													IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>

    {
		public ProEventsContext(DbContextOptions<ProEventsContext> options) : base(options) { }
		public DbSet<Event> Events { get; set; }
		public DbSet<Speaker> Speakers { get; set; }
		public DbSet<Social> Socials { get; set; }
		public DbSet<TicketLot> TicketLots { get; set; }
		public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserRole>(ur => 
			{
				ur.HasKey(u => new { u.UserId , u.RoleId });

				ur.HasOne(u => u.Role)
					.WithMany(role => role.UserRoles)
					.HasForeignKey(userRole => userRole.RoleId)
					.IsRequired();

                ur.HasOne(u => u.User)
                    .WithMany(user => user.UserRoles)
                    .HasForeignKey(userRole => userRole.UserId)
                    .IsRequired();
            });

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