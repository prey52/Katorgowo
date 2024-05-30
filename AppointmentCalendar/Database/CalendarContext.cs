using AppointmentCalendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace AppointmentCalendar.Database
{
    public class CalendarContext : DbContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options)
        {
        }

        public DbSet<WydarzeniaModel> Wydarzenia { get; set; }
        public DbSet<KalendarzModel> Kalendarz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WydarzeniaModel>().HasKey(x => x.Id);
            modelBuilder.Entity<KalendarzModel>().HasKey(x => x.Id);
        }
    }
}
