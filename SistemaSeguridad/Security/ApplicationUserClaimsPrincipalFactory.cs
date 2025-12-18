using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SistemaSeguridad.Security
{
    /// <summary>
    /// Agrega al usuario los claims de permisos que están definidos en sus roles.
    /// </summary>
    public class ApplicationUserClaimsPrincipalFactory
        : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            // 1. Obtener los roles del usuario
            var roles = await UserManager.GetRolesAsync(user);

            foreach (var roleName in roles)
            {
                var role = await RoleManager.FindByNameAsync(roleName);
                if (role == null) continue;

                // 2. Obtener los claims (permisos) asociados a ese rol
                var roleClaims = await RoleManager.GetClaimsAsync(role);

                // 3. Agregar al usuario solo los claims de tipo "permission"
                foreach (var claim in roleClaims.Where(c => c.Type == "permission"))
                {
                    identity.AddClaim(new Claim("permission", claim.Value));
                }
            }

            return identity;
        }
    }
}
