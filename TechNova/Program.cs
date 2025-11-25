using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechNova.Models;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<TechNovaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<TechNovaContext>()
.AddDefaultTokenProviders()
.AddDefaultUI(); // <-- agrega la UI por defecto (login/register)

// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // <-- ESTO ARREGLA TU ERROR

var app = builder.Build();

// Crear usuario admin por defecto
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string adminRole = "Administrador";
    string adminEmail = "mathew@gmail.com";
    string adminPassword = "Admin123#";

    if (!await roleManager.RoleExistsAsync(adminRole))
    {
        await roleManager.CreateAsync(new IdentityRole(adminRole));
    }

    var existingUser = await userManager.FindByEmailAsync(adminEmail);
    if (existingUser == null)
    {
        var newAdmin = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail
        };

        var result = await userManager.CreateAsync(newAdmin, adminPassword);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdmin, adminRole);
        }
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // <-- OBLIGATORIO para el login y registro

app.Run();
