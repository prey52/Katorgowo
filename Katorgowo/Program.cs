using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Katorgowo.Areas.Identity.Data;
using Katorgowo.Areas.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KatorgowoDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("KatorgowoKonta"))
);

//identity
builder.Services.AddDefaultIdentity<DBUser>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<KatorgowoDBContext>();

//http clinet
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=ListaOgloszen}/{id?}");

//do obs�ugi widok�w m.in. Identity
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

//Seedowanie:
//Tworzenie r�l u�ytkownika (je�eli nie istniej�)
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Recruiter", "User" };

    foreach (var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

//tworzenie domy�lnego admina
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DBUser>>();

    string email = "test123@gmail.com";
    string password = "Test123#";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new DBUser();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "admin";
        user.LastName = "admin";
        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }

}

app.Run();