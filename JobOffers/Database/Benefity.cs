using JobOffers.Models;

namespace OfertyPracy.Database
{
    public class Benefity
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        // Klucz obcy do JobPost
        public int OfertaPracyId { get; set; }
        public OfertyPracyModel OfertaPracy { get; set; }
    }
}
