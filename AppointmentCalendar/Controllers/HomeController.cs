using AppointmentCalendar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AppointmentCalendar.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppointmentCalendar.Database;
using System.Globalization;

namespace AppointmentCalendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalendarContext _context;

        public HomeController(CalendarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] WydarzeniaViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Model is null");
            }

            try
            {
                
                // Konwersja daty i czasu
                var data = DateOnly.Parse(model.Data);
                var start = TimeOnly.Parse(model.Start);
                var end = TimeOnly.Parse(model.End);

                var wydarzenie = new WydarzeniaModel
                {
                    IdRekrutera = model.IdRekrutera,
                    Data = data,
                    Start = start,
                    End = end
                };

                _context.Wydarzenia.Add(wydarzenie);
                await _context.SaveChangesAsync();

                return Json(new { success = true, eventId = wydarzenie.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddEvent: {ex.Message}");
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent([FromBody] WydarzeniaViewModel model)
        {
            if (model == null)
            {
                Console.WriteLine("Model is null in EditEvent");
                return Json(new { success = false, message = "Model is null" });
            }

            try
            {
                var existingEvent = await _context.Wydarzenia.FindAsync(model.Id);
                if (existingEvent != null)
                {
                    Console.WriteLine("Edytuje");

                    var data = DateOnly.Parse(model.Data);
                    var start = TimeOnly.Parse(model.Start);
                    var end = TimeOnly.Parse(model.End);

                
                    existingEvent.IdRekrutera = model.IdRekrutera;
                    existingEvent.Data = data;
                    existingEvent.Start = start;
                    existingEvent.End = end;
                    await _context.SaveChangesAsync();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EditEvent: {ex.Message}");
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var existingEvent = await _context.Wydarzenia.FindAsync(id);
                if (existingEvent != null)
                {
                    _context.Wydarzenia.Remove(existingEvent);
                    await _context.SaveChangesAsync();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteEvent: {ex.Message}");
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _context.Wydarzenia.Select(e => new
            {
                id = e.Id,
                title = $"Wolny: {e.Start.ToString("HH:mm")} - {e.End.ToString("HH:mm")}",
                start = e.Data.ToDateTime(e.Start).ToString("yyyy-MM-ddTHH:mm:ss"),
                end = e.Data.ToDateTime(e.End).ToString("yyyy-MM-ddTHH:mm:ss"),

            }).ToList();

            return Json(events);
        }

        [HttpGet]
        public async Task<IActionResult> GetEventDetails(int eventId)
        {
            try
            {
                var eventDetails = await _context.Wydarzenia.FindAsync(eventId);
                if (eventDetails != null)
                {
                    return Json(new
                    {
                        id = eventDetails.Id,
                        date = eventDetails.Data.ToString("yyyy-MM-dd"),
                        startTime = eventDetails.Start.ToString("HH:mm"),
                        endTime = eventDetails.End.ToString("HH:mm"),
                        recruiterId = eventDetails.IdRekrutera
                    });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B³¹d podczas pobierania szczegó³ów wydarzenia: {ex.Message}");
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveEvent([FromBody] WydarzeniaViewModel model)
        {
            if (model == null)
            {
                Console.WriteLine("Model is null in SaveEvent");
                return Json(new { success = false, message = "Model is null" });
            }

            try
            {
                var existingEvent = await _context.Wydarzenia.FindAsync(model.Id);
                if (existingEvent != null)
                {
                    existingEvent.IdRekrutera = model.IdRekrutera;
                    await _context.SaveChangesAsync();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SaveEvent: {ex.Message}");
                return Json(new { success = false, message = ex.Message });
            }
        }


    }
}
