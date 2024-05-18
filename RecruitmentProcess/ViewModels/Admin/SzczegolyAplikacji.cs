using Microsoft.AspNetCore.Mvc;

namespace RecruitmentProcess.ViewModels.Admin
{
    public class SczegolyAplikacjiViewModel
    {
        public int IdAplikacji { get; set; }
        public int IdOgloszenia { get; set; }
        public int IdRekrutera { get; set; }
        public int IdUzytkownika { get; set; }
        public string Tresc { get; set; }
        public DateTime DataAplikacji { get; set; }
        public byte[] PlikCV { get; set; }
        public List<string> Status { get; set; }
    }
}
