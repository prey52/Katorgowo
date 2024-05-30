using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppointmentCalendar.Models
{

    public class WydarzeniaModel
    {
        [Key]
        public int Id { get; set; }
        public int IdAplikacji { get; set; }
        public int IdRekrutera { get; set; }
        public DateTime DataSpotkania { get; set; }
    }
}
