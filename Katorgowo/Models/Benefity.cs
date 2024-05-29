namespace Katorgowo.Models
{
    public class Benefity
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public int OfertaPracyId { get; set; }
        public OfertyPracyModel OfertaPracy { get; set; }
    }
}
