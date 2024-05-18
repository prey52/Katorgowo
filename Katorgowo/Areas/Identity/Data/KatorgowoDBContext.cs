using Katorgowo.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Katorgowo.Areas.Identity.Data;

public class KatorgowoDBContext : IdentityDbContext<DBUser>
{
    private readonly HttpClient _httpClient;

    public KatorgowoDBContext(DbContextOptions<KatorgowoDBContext> options) : base(options)
    {
        _httpClient = httpClient;
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