using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using JobOffers.Models;

namespace JobOffers.Database
{
    public class OfertyPracyDBcontext : DbContext
    {
        public OfertyPracyDBcontext(DbContextOptions<OfertyPracyDBcontext> options) : base(options)
        {

        }
        public DbSet<OfertyPracyModel> OfertyPracy { get; set; }

    }
}
