using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobOffers.Models
{
    public class OfertyPracyModel
    {
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
        public string Benefity { get; set; }

        public OfertyPracyModel(int id, int idrekturera, string status, string tytul, string kategoria, string opis, DateTime datadodania,
            DateTime datapublikacji, DateTime datawaznosci, string wymagania, string wynagrodzenie, string wymiarpracy, string rodzajumowy, string benefity)
        {
            Id = id;
            IdRekrutera = idrekturera;
            Status = status;
            Tytuł = tytul;
            Kategoria = kategoria;
            Opis = opis;
            DataDodania = datadodania;
            DataPublikacji = datapublikacji;
            DataWaznosci = datawaznosci;
            Wymagania = wymagania;
            Wynagrodzenie = wynagrodzenie;
            WymiarPracy = wymiarpracy;
            RodzajUmowy = rodzajumowy;
            Benefity = benefity;
        }
    }
}
