using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Katorgowo.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("KatorgowoDBContextConnection") ?? 
    throw new InvalidOperationException("Connection string 'KatorgowoDBContextConnection' not found.");

//dbcontext
builder.Services.AddDbContext<KatorgowoDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Katorgowo"))
    );

//identity
builder.Services.AddDefaultIdentity<DBUser>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<KatorgowoDBContext>();

//http clinet
builder.Services.AddHttpClient();


//services.AddHttpClient();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

//do obs³ugi widoków m.in. Identity
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

//Seedowanie:
//Tworzenie ról u¿ytkownika (je¿eli nie istniej¹)
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

//tworzenie domyœlnego admina
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
        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }

}

app.Run();

/*
TODO:
Poprawa:
-rola
-data

*/