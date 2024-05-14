using Microsoft.AspNetCore.Mvc;
using RecruitmentProcess.Models;

namespace RecruitmentProcess.ViewModels.Admin
{
    public class ListaAplikacjiViewModel
    {
        public int IdAplikacji { get; set; }
        public DateTime DataAplikacji { get; set; }
        public Status Status { get; set; }
    }
}
