using Azure;
using Katorgowo.Areas.Identity;
using Katorgowo.Areas.Identity.Data;
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
        private readonly KatorgowoDBContext _dbContext;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, UserManager<DBUser> userManager, KatorgowoDBContext context)
        {
            _logger = logger;
            _httpClient = httpClient;
            _userManager = userManager;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> DodajOgloszenie()
        {
            var recruiter = await _userManager.GetUserAsync(User);
            var localizationFilled = _dbContext.LokalizacjeFirm.FirstOrDefault(x => x.DbuserID == recruiter.Id);

            if(localizationFilled == null)
            {
                return Redirect("/Identity/Account/Manage/Lokalizacja");
            }
            else
            {
                return View("/Views/OfertyPracy/DodajOgloszenie.cshtml");
            }
            
        }

        public async Task<IActionResult> Wyslij(OfertyPracyDTO jobOfferDto)
        {
            var url = "https://localhost:7029/api/OfertyPracy";

            jobOfferDto.Status = "Oczekuj¹ca";
            jobOfferDto.DataStworzenia = DateTime.Now;
            jobOfferDto.DataPublikacji = DateTime.Now; //do zmiany

            await _httpClient.PostAsJsonAsync(url, jobOfferDto);

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
                    LokalizacjaFirmy = null //do zmiany
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
