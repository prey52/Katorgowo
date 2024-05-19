using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class KalendarzController : Controller
{
    // Akcja Index wyświetla widok kalendarza
    public IActionResult Index()
    {
        return View();
    }

    // Akcja Wydarzenia zwraca wydarzenia do kalendarza
    public IActionResult Wydarzenia()
    {
        // Tutaj pobierz wydarzenia z bazy danych lub innego źródła danych
        // i zwróć je w formacie, który obsługuje FullCalendar
        List<object> wydarzenia = new List<object>
        {
            new
            {
                id = 1,
                title = "Spotkanie",
                start = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                end = DateTime.Now.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ss"),
                description = "Spotkanie zespołu"
            },
            new
            {
                id = 2,
                title = "Prezentacja",
                start = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ss"),
                end = DateTime.Now.AddDays(1).AddHours(2).ToString("yyyy-MM-ddTHH:mm:ss"),
                description = "Prezentacja produktu"
            }
        };

        return Json(wydarzenia);
    }
}
