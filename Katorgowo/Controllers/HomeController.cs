using Azure;
using Katorgowo.Areas.Identity;
using Katorgowo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NuGet.Protocol;
using System.Diagnostics;

namespace Katorgowo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly UserManager<DBUser> _userManager;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, UserManager<DBUser> userManager)
        {
            _logger = logger;
            _httpClient = httpClient;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DodajOgloszenie()
        {
            return View("/Views/OfertyPracy/DodajOgloszenie.cshtml");
        }

        public async Task<IActionResult> Wyslij(OfertyPracyModel model)
        {
            var url = "https://localhost:7029/api/OfertyPracy";

            model.Status = "Oczekuj¹cy";
            model.DataStworzenia = DateTime.Now;
            model.DataPublikacji = DateTime.Now;
            //przeniesienie zmian do kontrolera ofert pracy z jakiegoœ powodu nie dzia³a o_0

            await _httpClient.PostAsJsonAsync(url, model);

            return RedirectToAction("ListaOgloszen");
        }

        public async Task<IActionResult> ListaOgloszen()
        {
            var url = "https://localhost:7029/api/OfertyPracy";
            var jobOffers = await _httpClient.GetFromJsonAsync<List<OfertyPracyModel>>(url);

            List<OfertyPracyUserViewModel> result = new List<OfertyPracyUserViewModel>();

            foreach (var item in jobOffers)
            {
                var user = await _userManager.FindByIdAsync(item.IdRekrutera);
                OfertyPracyUserViewModel tmp = new OfertyPracyUserViewModel()
                {
                    Id = item.Id,
                    IdRekrutera = item.IdRekrutera,
                    Status = item.Status,
                    Tytu³ = item.Tytu³,
                    Kategoria = item.Kategoria,
                    Opis = item.Opis,
                    DataStworzenia = item.DataStworzenia,
                    DataPublikacji = item.DataPublikacji,
                    DataWaznosci = item.DataWaznosci,
                    Wynagrodzenie = item.Wynagrodzenie,
                    WymiarPracy = item.WymiarPracy,
                    RodzajUmowy = item.RodzajUmowy, 
                    NazwaFirmy = user.CompanyName,
                    LogoFirmy = Convert.ToBase64String(user.CompanyLogo),
                    LokalizacjaFirmy = user.CompanyLocalization
                };
                result.Add(tmp);
            }

            return View("/Views/OfertyPracy/UserListaOgloszen.cshtml", result);
        }

        public async Task<IActionResult> Ogloszenie(int id)
        {
            var url = $"https://localhost:7029/api/OfertyPracy/{id}";
            OfertyPracyModel oferta = await _httpClient.GetFromJsonAsync<OfertyPracyModel>(url);

            return View("/Views/OfertyPracy/UserSzczegolyOferty.cshtml", oferta);
        }
         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
