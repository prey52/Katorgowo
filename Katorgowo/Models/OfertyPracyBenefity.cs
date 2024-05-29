using System.ComponentModel.DataAnnotations.Schema;

namespace Katorgowo.Models
{
    public class OfertyPracyBenefity
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        // Klucz obcy do ofert
        public int OfertaPracyId { get; set; }
        public OfertyPracyModel OfertaPracy { get; set; }
    }
}
