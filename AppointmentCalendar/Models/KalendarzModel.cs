using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppointmentCalendar.Models
{
    public class KalendarzModel
    {
        [Key]
        public int Id { get; set; }
        public int IdRekrutera { get; set; }
        public List<DateTime> WolneTerminy { get; set; }
    }
}
