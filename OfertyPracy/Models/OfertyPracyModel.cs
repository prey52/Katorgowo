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
        public string IdRekrutera { get; set; }
        public string Status { get; set; }
        public string Tytul { get; set; }
        public string Kategoria { get; set; }
        public string Opis { get; set; }
        public DateTime DataStworzenia { get; set; }
        public DateTime DataPublikacji { get; set; }
        public DateTime DataWaznosci { get; set; }
        public ICollection<OfertyPracyWymagania> Wymagania { get; set; } = new List<OfertyPracyWymagania>();
        public ICollection<OfertyPracyBenefity> Benefity { get; set; } = new List<OfertyPracyBenefity>();
        public string Wynagrodzenie { get; set; }
        public string WymiarPracy { get; set; }
        public string RodzajUmowy { get; set; }

        public OfertyPracyModel()
        {

        }
    }
}
