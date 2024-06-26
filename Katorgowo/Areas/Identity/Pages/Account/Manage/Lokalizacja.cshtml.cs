﻿using Katorgowo.Areas.Identity.Data;
using Katorgowo.Areas.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class LokalizacjaModel : PageModel
{
    public readonly KatorgowoDBContext _dbContext;
    private readonly UserManager<DBUser> _userManager;
    private readonly SignInManager<DBUser> _signInManager;

    public LokalizacjaModel(KatorgowoDBContext dbContext, UserManager<DBUser> userManager, SignInManager<DBUser> signInManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public string Username { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Display(Name = "Województwo")]
        public string Województwo { get; set; }

        [Display(Name = "Miasto")]
        public string Miasto { get; set; }

        [Display(Name = "Ulica")]
        public string Ulica { get; set; }

        [Display(Name = "NrLokalu")]
        public string NrLokalu { get; set; }

        [Display(Name = "KodPocztowy")]
        public string KodPocztowy { get; set; }
    }

    private async Task LoadAsync(DBUser user)
    {
        var userName = await _userManager.GetUserNameAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        if (!roles.Contains("Recruiter"))
        {
            Redirect("/Identity/Account/Manage/Index");
        }

        var recruiter = await _userManager.GetUserAsync(User);
        var localizationFilled = _dbContext.LokalizacjeFirm.FirstOrDefault(x => x.DbuserID == recruiter.Id);

        if (localizationFilled != null)
        {
            Input = new InputModel
            {
                Województwo = localizationFilled.Wojewodztwo,
                Miasto = localizationFilled.Miasto,
                Ulica = localizationFilled.Ulica,
                NrLokalu = localizationFilled.NrLokalu,
                KodPocztowy = localizationFilled.KodPocztowy
            };
        }
        
        else
        {
            Input = new InputModel
            {
                Województwo = "",
                Miasto = "",
                Ulica = "",
                NrLokalu = "",
                KodPocztowy = ""
            };
        }
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        await LoadAsync(user);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        var roles = await _userManager.GetRolesAsync(user);

        if (roles.Contains("Recruiter"))
        {
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var recruiter = await _userManager.GetUserAsync(User);
            var localizationFilled = _dbContext.LokalizacjeFirm.FirstOrDefault(x => x.DbuserID == recruiter.Id);

            if (localizationFilled == null)
            {
                localizationFilled = new LokalizacjaFirmy
                {
                    DbuserID = recruiter.Id
                };
                _dbContext.LokalizacjeFirm.Add(localizationFilled);
            }

            localizationFilled.Wojewodztwo = Input.Województwo;
            localizationFilled.Miasto = Input.Miasto;
            localizationFilled.Ulica = Input.Ulica;
            localizationFilled.NrLokalu = Input.NrLokalu;
            localizationFilled.KodPocztowy = Input.KodPocztowy;

            await _dbContext.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
        else
        {
            return Redirect("/Identity/Account/Manage/Index");
        }
    }
}
