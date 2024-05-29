using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using JobOffers.Models;
using OfertyPracy.Database;

namespace JobOffers.Database
{
    public class OfertyPracyDBcontext : DbContext
    {
        public OfertyPracyDBcontext(DbContextOptions<OfertyPracyDBcontext> options) : base(options)
        {

        }
        public DbSet<OfertyPracyModel> OfertyPracy { get; set; }
        public DbSet<Benefity> Benefity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //jeden do wielu
            modelBuilder.Entity<OfertyPracyModel>()
                .HasMany(j => j.Benefity)
                .WithOne(b => b.OfertaPracy)
                .HasForeignKey(b => b.OfertaPracyId);
        }

    }

    
}
