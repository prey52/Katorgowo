using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZarzadzanieKontami.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KontaUzytkownikowDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("KatorgowoKontaUzytkownikow"))
    );

//identity
builder.Services.AddDefaultIdentity<DBUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<KontaUzytkownikowDBContext>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Seedowanie:
//Tworzenie ról u¿ytkownika (je¿eli nie istniej¹)
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Rekruter", "Uzytkownik" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
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
        user.FirstName = "admin";
        user.LastName = "admin";
        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }

}

app.Run();
