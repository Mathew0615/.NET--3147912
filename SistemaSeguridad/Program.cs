using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaSeguridad.Data;
using SistemaSeguridad.Security; // Permissions y ApplicationUserClaimsPrincipalFactory

var builder = WebApplication.CreateBuilder(args);

// =======================================
//  BASE DE DATOS (EF CORE + SQL SERVER)
// =======================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
    )
);

// =======================================
//   IDENTITY + ROLES
// =======================================
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

    // Config contraseña (ajusta si quieres)
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// 👇 FACTORY PERSONALIZADA QUE AGREGA LOS PERMISOS (claims) DEL ROL AL USUARIO
builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, ApplicationUserClaimsPrincipalFactory>();

// =======================================
//   COOKIES (LOGIN / ACCESS DENIED)
// =======================================
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

// =======================================
//   AUTORIZACIÓN BASADA EN PERMISOS
// =======================================
builder.Services.AddAuthorization(options =>
{
    // Creamos una policy por cada permiso definido en Permissions.All
    foreach (var permission in Permissions.All)
    {
        options.AddPolicy(permission, policy =>
        {
            policy.RequireClaim("permission", permission);
        });
    }
});

// =======================================
//   MVC + RAZOR PAGES
// =======================================
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// =======================================
//   BUILD
// =======================================
var app = builder.Build();

// =======================================
//   PIPELINE HTTP
// =======================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

// Rutas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// =======================================
//   SEED (ROLES, USUARIOS, PERMISOS)
// =======================================
await DbInitializer.SeedAsync(app.Services);

// =======================================
//   RUN
// =======================================
app.Run();
