using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeU_EventManagementSystem_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<EventSponsor> EventSponsors { get; set; }
        public DbSet<QRCheckIn> QRCheckIns { get; set; }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
    }

}
