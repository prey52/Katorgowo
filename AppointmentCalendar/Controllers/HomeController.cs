using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class HomeController : Controller
{
    private static List<EventViewModel> events = new List<EventViewModel>();
    private static int eventIdCounter = 1;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddEvent(EventViewModel model)
    {
        model.Id = eventIdCounter++;
        events.Add(model);
        return Json(new { success = true, eventId = model.Id });
    }

    [HttpPost]
    public IActionResult EditEvent(EventViewModel model)
    {
        var existingEvent = events.Find(e => e.Id == model.Id);
        if (existingEvent != null)
        {
            existingEvent.Title = model.Title;
            existingEvent.Start = model.Start;
            existingEvent.End = model.End;
        }
        return Json(new { success = true });
    }

    [HttpPost]
    public IActionResult DeleteEvent(int id)
    {
        var existingEvent = events.Find(e => e.Id == id);
        if (existingEvent != null)
        {
            events.Remove(existingEvent);
        }
        return Json(new { success = true });
    }

    [HttpGet]
    public IActionResult GetEvents()
    {
        return Json(events);
    }
}

public class EventViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
