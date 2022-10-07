using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
     
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;
        public DbSet<Alarm> Alarms { get; set; } = null!;
        public DbSet<AlarmType> AlarmTypes { get; set; } = null!;
        public DbSet<Config> Configs { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventStatus> EventStatuses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Queue> Queue { get; set; } = null!;
        public DbSet<OrderDetails> OrderDetails { get; set; } = null!;
        public DbSet<Article> Article { get; set; } = null!;
    }
}
