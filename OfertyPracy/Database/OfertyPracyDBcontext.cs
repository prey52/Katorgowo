using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using JobOffers.Models;
using OfertyPracy.Database;

namespace OfertyPracy.Database
{
    public class OfertyPracyDBcontext : DbContext
    {
        public OfertyPracyDBcontext(DbContextOptions<OfertyPracyDBcontext> options) : base(options)
        {

        }
        public DbSet<OfertyPracyModel> OfertyPracy { get; set; }
        public DbSet<OfertyPracyBenefity> Benefity { get; set; }
        public DbSet<OfertyPracyWymagania> Wymagania { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //jeden do wielu z benefitami
            /*modelBuilder.Entity<OfertyPracyModel>()
                .HasMany(j => j.Benefity)
                .WithOne(b => b.OfertaPracy)
                .HasForeignKey(b => b.OfertaPracyId);

            //jeden do wielu z wymaganiami
            modelBuilder.Entity<OfertyPracyModel>()
                .HasMany(j => j.Wymagania)
                .WithOne(b => b.OfertaPracy)
                .HasForeignKey(b => b.OfertaPracyId);*/
        }

    }
}
