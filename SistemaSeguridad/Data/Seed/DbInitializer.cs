using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSeguridad.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider service)
        {
            using var scope = service.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // ================================
            //   1. ROLES INICIALES DEL SISTEMA
            // ================================
            string[] roles = new[]
            {
                "Administrador",
                "Supervisor",
                "Empleado",
                "Cliente"
            };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // ================================
            //   2. USUARIO ADMINISTRADOR
            // ================================
            var adminEmail = "admin@chocoadmin.com";
            var adminPassword = "Admin123$";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (!result.Succeeded)
                    throw new Exception("Error creando usuario admin: " +
                        string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            // asignar TODOS los roles al admin
            foreach (var role in roles)
            {
                if (!await userManager.IsInRoleAsync(adminUser, role))
                {
                    await userManager.AddToRoleAsync(adminUser, role);
                }
            }

            // ================================
            //   3. USUARIO EMPLEADO (opcional)
            // ================================
            var empleadoEmail = "empleado@chocoadmin.com";
            var empleadoPassword = "Empleado123$";

            var empleado = await userManager.FindByEmailAsync(empleadoEmail);

            if (empleado == null)
            {
                empleado = new IdentityUser
                {
                    UserName = empleadoEmail,
                    Email = empleadoEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(empleado, empleadoPassword);

                if (!result.Succeeded)
                    throw new Exception("Error creando usuario empleado: " +
                        string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            // asignar solo rol Empleado
            if (!await userManager.IsInRoleAsync(empleado, "Empleado"))
            {
                await userManager.AddToRoleAsync(empleado, "Empleado");
            }

            // ================================
            //   LISTO ✔️ Seed avanzado creado
            // ================================
        }
    }
}
