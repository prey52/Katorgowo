using Microsoft.AspNetCore.Mvc;
using RecruitmentProcess.Models;
//using AccountMenagment.Models

namespace RecruitmentProcess.ViewModels.Rekruter
{

    public class ListaAplikacjiViewModel
    {
        public string TytulOgloszenia { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataAplikacji { get; set; }
        public string Status { get; set; }
    }
}

