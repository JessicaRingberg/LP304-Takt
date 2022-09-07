using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<AlarmType> AlarmTypes { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Queue> Queue { get; set; }
    }
}
