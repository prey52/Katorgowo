using Microsoft.AspNetCore.Mvc;

namespace RecruitmentProcess.Models
{
    public enum Status
    {
        Oczekujace,
        Zaakceptowane,
        Odrzucone
    }

    public class ZgloszeniaModel
    {
        public int Id { get; set; }
        public int IdAplikacji { get; set; }
        public DateTime DataZgloszenia { get; set; }
        public string TrescZgloszenia { get; set; }
        public Status Status { get; set; }
    }
}
