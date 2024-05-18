using Microsoft.AspNetCore.Mvc;
using RecruitmentProcess.Models;

namespace RecruitmentProcess.ViewModels.Admin
{
    public class ZgloszenieViewModel
    {
        public int IdAplikacji { get; set; }
        public int IdOgloszenia { get; set; }
        public int IdRekrutera { get; set; }
        public int IdUzytkownika { get; set; }
        public string Tresc { get; set; }
        public DateTime DataAplikacji { get; set; }
        public byte[] PlikCV { get; set; }
        public Status Status { get; set; }
        public DateTime DataZgloszenia { get; set; }
        public string TrescZgloszenia { get; set; }
    }
}
