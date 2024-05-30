using Microsoft.AspNetCore.Mvc;

namespace AppointmentCalendar.Models
{
    public class KalendarzModel
    {
        public int IdRekrutera { get; set; }
        public List<DateTime> WolneTerminy { get; set; }
    }
}
