using Microsoft.AspNetCore.Mvc;

namespace RecruitmentProcess.ViewModels.User
{
    public class SczegolyAplikacjiViewModel
    {
        public int IdOgloszenia { get; set; }
        public string TytulOgloszenia { get; set; }
        public string Tresc { get; set; }
        public DateTime DataAplikacji { get; set; }
        public byte[] PlikCV { get; set; }
        public List<string> Status { get; set; }
    }
}
