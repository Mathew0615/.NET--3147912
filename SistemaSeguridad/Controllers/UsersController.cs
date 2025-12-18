using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.Models.ViewModels;

namespace SistemaSeguridad.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsersController : Controller
    {
        private const string ProtectedRoleName = "Administrador";
        private const string SuperRoleName = "SuperAdministrador";

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private bool IsSuperAdmin() => User.IsInRole(SuperRoleName);

        private async Task<bool> TargetUserIsAdminAsync(IdentityUser user)
            => await _userManager.IsInRoleAsync(user, ProtectedRoleName);

        private IActionResult Deny(string message)
        {
            TempData["ErrorMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var model = new System.Collections.Generic.List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                model.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email ?? user.UserName ?? string.Empty,
                    UserName = user.UserName,
                    EmailConfirmed = user.EmailConfirmed,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    Roles = roles
                });
            }

            return View(model);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var roles = await _userManager.GetRolesAsync(user);

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email ?? user.UserName ?? string.Empty,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEnd = user.LockoutEnd,
                Roles = roles
            };

            return View(model);
        }

        // GET: Users/ManageRoles/5
        public async Task<IActionResult> ManageRoles(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            // ✅ PROTECCIÓN: si el usuario objetivo es Admin, solo SuperAdministrador lo puede modificar
            if (await TargetUserIsAdminAsync(user) && !IsSuperAdmin())
                return Deny("No tienes permisos para modificar roles de un usuario Administrador.");

            var model = new ManageUserRolesViewModel
            {
                UserId = user.Id,
                Email = user.Email ?? user.UserName ?? string.Empty,
                UserName = user.UserName
            };

            var allRoles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in allRoles)
            {
                model.Roles.Add(new RoleSelectionViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name!,
                    IsSelected = userRoles.Contains(role.Name!)
                });
            }

            return View(model);
        }

        // POST: Users/ManageRoles/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(ManageUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();

            // ✅ PROTECCIÓN: no tocar usuarios Admin si no eres SuperAdministrador
            if (await TargetUserIsAdminAsync(user) && !IsSuperAdmin())
                return Deny("No tienes permisos para modificar roles de un usuario Administrador.");

            var currentRoles = await _userManager.GetRolesAsync(user);
            var selectedRoles = model.Roles
                .Where(r => r.IsSelected)
                .Select(r => r.RoleName)
                .ToList();

            // ✅ PROTECCIÓN EXTRA: impedir que un admin normal asigne/quites el rol Administrador a cualquiera
            if (!IsSuperAdmin())
            {
                bool isTryingToChangeAdminRole =
                    currentRoles.Contains(ProtectedRoleName) != selectedRoles.Contains(ProtectedRoleName);

                if (isTryingToChangeAdminRole)
                    return Deny("No tienes permisos para asignar o quitar el rol Administrador.");
            }

            var rolesToRemove = currentRoles.Where(r => !selectedRoles.Contains(r)).ToList();
            if (rolesToRemove.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                if (!removeResult.Succeeded)
                {
                    foreach (var error in removeResult.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return View(model);
                }
            }

            var rolesToAdd = selectedRoles.Where(r => !currentRoles.Contains(r)).ToList();
            if (rolesToAdd.Any())
            {
                var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);
                if (!addResult.Succeeded)
                {
                    foreach (var error in addResult.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return View(model);
                }
            }

            TempData["SuccessMessage"] = "Roles del usuario actualizados correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // POST: Users/Lock/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lock(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            // ✅ PROTECCIÓN: no bloquear Admin si no eres SuperAdministrador
            if (await TargetUserIsAdminAsync(user) && !IsSuperAdmin())
                return Deny("No tienes permisos para bloquear un usuario Administrador.");

            user.LockoutEnabled = true;
            user.LockoutEnd = System.DateTimeOffset.UtcNow.AddYears(1);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                TempData["SuccessMessage"] = "Usuario bloqueado correctamente.";
            else
                TempData["ErrorMessage"] = "No se pudo bloquear el usuario.";

            return RedirectToAction(nameof(Index));
        }

        // POST: Users/Unlock/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Unlock(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            // ✅ PROTECCIÓN: no desbloquear Admin si no eres SuperAdministrador
            if (await TargetUserIsAdminAsync(user) && !IsSuperAdmin())
                return Deny("No tienes permisos para desbloquear un usuario Administrador.");

            user.LockoutEnd = null;
            user.LockoutEnabled = false;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                TempData["SuccessMessage"] = "Usuario desbloqueado correctamente.";
            else
                TempData["ErrorMessage"] = "No se pudo desbloquear el usuario.";

            return RedirectToAction(nameof(Index));
        }
    }
}
