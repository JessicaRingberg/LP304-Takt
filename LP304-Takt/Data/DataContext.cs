﻿using System.ComponentModel.DataAnnotations.Schema;
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
        //public DbSet<Alarm> Alarm { get; set; }
        //public DbSet<AlarmType> AlarmType { get; set; }
        //public DbSet<Config> Config { get; set; }
        //public DbSet<Event> Event { get; set; }
        //public DbSet<EventStatus> EventStatus { get; set; }
        //public DbSet<Order> Order { get; set; }
        //public DbSet<Queue> Queue { get; set; }
    }
}
