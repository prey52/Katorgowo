using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace JobOffers.Models
{
    public class JobOffersDBcontext : DbContext
    {
        public JobOffersDBcontext(DbContextOptions<JobOffersDBcontext> options) : base(options)
        {

        }
        public DbSet<JobOffer> JobOffers { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seedowanie danych
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Informatyka" },
                new Category { Id = 2, Name = "Medycyna" },
                new Category { Id = 3, Name = "Finanse" },
                new Category { Id = 4, Name = "Edukacja" },
                new Category { Id = 5, Name = "Inżynieria" },
                new Category { Id = 6, Name = "Handel" },
                new Category { Id = 7, Name = "Sztuka i design" },
                new Category { Id = 8, Name = "Administracja" },
                new Category { Id = 9, Name = "Sprzedaż" },
                new Category { Id = 10, Name = "Prawo" },
                new Category { Id = 11, Name = "Marketing" },
                new Category { Id = 12, Name = "Produkcja" },
                new Category { Id = 13, Name = "Transport" },
                new Category { Id = 14, Name = "Usługi" },
                new Category { Id = 15, Name = "Budownictwo" },
                new Category { Id = 16, Name = "Gastronomia" },
                new Category { Id = 17, Name = "Media i komunikacja" },
                new Category { Id = 18, Name = "Rolnictwo" },
                new Category { Id = 19, Name = "Nauka i badania" },
                new Category { Id = 20, Name = "Inne" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Oczekująca" },
                new Status { Id = 2, Name = "Odrzucona" },
                new Status { Id = 3, Name = "Opublikowana" }
            );

            modelBuilder.Entity<WorkingTime>().HasData(
                new WorkingTime { Id = 1, Name = "1/4 etatu" },
                new WorkingTime { Id = 2, Name = "1/2 etatu" },
                new WorkingTime { Id = 3, Name = "Pełen etat" },
                new WorkingTime { Id = 4, Name = "Inne" }
            );

            modelBuilder.Entity<ContractType>().HasData(
                new ContractType { Id = 1, Name = "Umowa o pracę" },
                new ContractType { Id = 2, Name = "Umowa zlecenie" },
                new ContractType { Id = 3, Name = "Umowa o dzieło" },
                new ContractType { Id = 4, Name = "Kontrakt B2B" },
                new ContractType { Id = 5, Name = "Umowa o pracę tymczasową" },
                new ContractType { Id = 6, Name = "Umowa na zastępstwo" },
                new ContractType { Id = 7, Name = "Umowa staż/praktyki" }
            );
        }*/
    }
}
