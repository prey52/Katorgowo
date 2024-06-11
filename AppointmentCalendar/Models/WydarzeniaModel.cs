using System.ComponentModel.DataAnnotations;

namespace AppointmentCalendar.Models
{
    public class WydarzeniaModel
    {
        [Key]
        public int Id { get; set; }
        public int IdRekrutera { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
    }
}
