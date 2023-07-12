using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class SacramentMeetingPlannerContext : DbContext
    {
        public SacramentMeetingPlannerContext (DbContextOptions<SacramentMeetingPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlanner.Models.Meeting> Meeting { get; set; }
        public DbSet<SacramentMeetingPlanner.Models.Hymn> Hymn { get; set; }
        public DbSet<SacramentMeetingPlanner.Models.Talk> Talk { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hymn>()
                .HasOne(c => c.Meeting)
                .WithMany(p => p.Hymns)
                .HasForeignKey(h => h.MeetingId);

            modelBuilder.Entity<Talk>()
                .HasOne(c => c.Meeting)
                .WithMany(p => p.Talks)
                .HasForeignKey(h => h.MeetingId);
        }
    }
}
