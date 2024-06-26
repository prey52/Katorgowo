﻿using Katorgowo.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Katorgowo.Areas.Identity.Data
{
    public class KatorgowoDBContext : IdentityDbContext<DBUser>
    {
        private readonly HttpClient _httpClient;

        public KatorgowoDBContext(DbContextOptions<KatorgowoDBContext> options) : base(options)
        {

        }

        public DbSet<DBUser> dBUsers { get; set; }
        public DbSet<LokalizacjaFirmy> LokalizacjeFirm {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DBUser>()
                .HasOne(x => x.CompanyLocalization)
                .WithOne(y => y.Dbuser)
                .HasForeignKey<LokalizacjaFirmy>(l => l.DbuserID);

            modelBuilder.ApplyConfiguration(new AppUserEntityConfiguration());
        }
    }
    public class AppUserEntityConfiguration : IEntityTypeConfiguration<DBUser>
    {
        public void Configure(EntityTypeBuilder<DBUser> modelBuilder)
        {
            modelBuilder.Property(x => x.FirstName).HasMaxLength(255);
            modelBuilder.Property(x => x.LastName).HasMaxLength(255);
            modelBuilder.Property(x => x.BirthDate);
            modelBuilder.Property(x => x.CompanyName).HasMaxLength(255);
            modelBuilder.Property(x => x.CompanyLogo);
        }
    }
}

