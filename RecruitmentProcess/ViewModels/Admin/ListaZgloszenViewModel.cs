using Microsoft.AspNetCore.Mvc;
using RecruitmentProcess.Models;

namespace RecruitmentProcess.ViewModels.Admin
{
    public class ListaZgloszenViewModel
    {
        public int IdAplikacji { get; set; }
        public DateTime DataAplikacji { get; set; }
        public Status Status { get; set; }
        public DateTime DataZgloszenia { get; set; }
    
    }
}