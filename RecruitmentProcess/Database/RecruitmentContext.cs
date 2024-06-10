using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecruitmentProcess.Models;
using System.Collections.Generic;
using System.Globalization;

namespace RecruitmentProcess.Database
{

    public class RecruitmentContext : DbContext
    {
        public RecruitmentContext(DbContextOptions<RecruitmentContext> options)
            : base(options)
        {
        }

        public DbSet<RekrutacjaModel> Rekrutacja { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RekrutacjaModel>().HasKey(x => x.Id);
            modelBuilder.Entity<ZgloszeniaModel>().HasKey(x => x.Id);
        }
    }
}