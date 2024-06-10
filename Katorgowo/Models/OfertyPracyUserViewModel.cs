using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Katorgowo.Models
{
    public class OfertyPracyUserViewModel
    {
        public int Id { get; set; }
        public string IdRekrutera { get; set; }
        public string Status { get; set; }
        public string Tytuł { get; set; }
        public string Kategoria { get; set; }
        public string Opis { get; set; }
        public DateTime DataStworzenia { get; set; }
        public DateTime DataPublikacji { get; set; }
        public DateTime DataWaznosci { get; set; }
        [AllowNull]
        public ICollection<OfertyPracyWymagania> Wymagania { get; set; } = new List<OfertyPracyWymagania>();
        public string Wynagrodzenie { get; set; }
        public string WymiarPracy { get; set; }
        public string RodzajUmowy { get; set; }
        [AllowNull]
        public ICollection<OfertyPracyBenefity> Benefity { get; set; } = new List<OfertyPracyBenefity>();
        public string NazwaFirmy { get; set; }
        public string LogoFirmy { get; set; }
        public string LokalizacjaFirmy { get; set; }
    }
}
