using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Models
{
    public class LP304Context: DbContext
    {
        public LP304Context(DbContextOptions<LP304Context> options)
            : base(options)
        {

        }
        public DbSet<Alarm> Alarm { get; set; }
        public DbSet<AlarmType> AlarmType { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Config> Config { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventStatus> EventStatus { get; set; }
        public DbSet<Mac> Mac { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderAlarm> OrderAlarm { get; set; }
        public DbSet<OrderEvent> OrderEvent { get; set; }
        public DbSet<Queue> Queue { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<User> User { get; set; }
    }
}
