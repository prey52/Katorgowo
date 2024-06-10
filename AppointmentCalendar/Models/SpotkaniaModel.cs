using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppointmentCalendar.Models
{
    public class SpotkaniaModel
    {
        [Key]
        public int Id { get; set; }
        public int IdWydarzenia { get; set; }
        public int IdAplikacji { get; set; }
    }
}
