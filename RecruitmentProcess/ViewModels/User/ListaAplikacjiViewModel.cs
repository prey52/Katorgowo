using Microsoft.AspNetCore.Mvc;
using RecruitmentProcess.Models;

namespace RecruitmentProcess.ViewModels.User
{

    public class ListaAplikacjiViewModel
    {
        public string TytulOgloszenia { get; set; }
        public string NazwaFirmy { get; set; }
        public byte[] LogoFirmy { get; set; }
        public DateTime DataAplikacji { get; set; }
        public Status Status { get; set; }
    }
}
