using Microsoft.AspNetCore.Mvc;

namespace AppointmentCalendar.Models
{

    public class WydarzeniaModel
    {
        public int IdWydarzenia { get; set; }
        public int IdAplikacji { get; set; }
        public int IdRekrutera { get; set; }
        public DateTime DataSpotkania { get; set; }
    }
}
