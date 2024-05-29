using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfertyPracy.Database;

namespace JobOffers.Models
{
    public class OfertyPracyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdRekrutera { get; set; }
        public string Status { get; set; }
        public string Tytuł { get; set; }
        public string Kategoria { get; set; }
        public string Opis { get; set; }
        public DateTime DataDodania { get; set; }
        public DateTime DataPublikacji { get; set; }
        public DateTime DataWaznosci { get; set; }
        public string Wymagania { get; set; }
        public string Wynagrodzenie { get; set; }
        public string WymiarPracy { get; set; }
        public string RodzajUmowy { get; set; }
        public ICollection<Benefity> Benefity { get; set; }

        public OfertyPracyModel()
        {

        }
    }
}
