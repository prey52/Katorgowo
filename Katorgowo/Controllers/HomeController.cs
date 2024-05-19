using Azure;
using Katorgowo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Diagnostics;
using System.Text.Json;

namespace Katorgowo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ListaOgloszen()
        {
            var url = "https://localhost:7029/api/OfertyPracy";
            List<OfertyPracyModel> ListaOfert = new List<OfertyPracyModel> ();
            var jobOffers = await _httpClient.GetFromJsonAsync<List<OfertyPracyModel>>(url);
            return View("/Views/OfertyPracy/UserListaOgloszen.cshtml", jobOffers);
        }

        public async Task<IActionResult> Ogloszenie(int id)
        {
            var url = $"https://localhost:7029/api/OfertyPracy/{id}";
            OfertyPracyModel oferta = await _httpClient.GetFromJsonAsync<OfertyPracyModel>(url);

            return View("/Views/SzczegolyOferty/UserSzczegolyOferty.cshtml", oferta);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
