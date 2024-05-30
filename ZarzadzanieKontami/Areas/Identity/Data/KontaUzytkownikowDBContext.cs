using ZarzadzanieKontami.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZarzadzanieKontami.Areas.Identity.Data;

public class KontaUzytkownikowDBContext : IdentityDbContext<DBUser>
{
    public KontaUzytkownikowDBContext(DbContextOptions<KontaUzytkownikowDBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AppUserEntityConfiguration());
    }
}
public class AppUserEntityConfiguration : IEntityTypeConfiguration<DBUser>
{
    public void Configure(EntityTypeBuilder<DBUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);
        builder.Property(x => x.BirthDate);
        builder.Property(x => x.CompanyName).HasMaxLength(255);
        builder.Property(x => x.CompanyLogo);
        builder.Property(x => x.CompanyLocalization).HasMaxLength(255);
    }
}