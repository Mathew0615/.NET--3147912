using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.Models.ViewModels;
using SistemaSeguridad.Security;

namespace SistemaSeguridad.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class RolesController : Controller
    {
        private const string ProtectedRoleName = "Administrador";
        private const string SuperRoleName = "SuperAdministrador";

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RolesController(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private bool IsSuperAdmin() => User.IsInRole(SuperRoleName);

        private IActionResult Deny(string message)
        {
            TempData["ErrorMessage"] = message;
            return RedirectToAction(nameof(Index));
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var roles = _roleManager.Roles.ToList();
            var model = new System.Collections.Generic.List<RoleViewModel>();

            foreach (var role in roles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);

                model.Add(new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name!,
                    UsersCount = usersInRole.Count
                });
            }

            return View(model);
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);
            ViewBag.Users = usersInRole;

            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!,
                UsersCount = usersInRole.Count
            };

            return View(model);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View(new RoleViewModel());
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var roleExists = await _roleManager.RoleExistsAsync(model.Name);
            if (roleExists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe un rol con ese nombre.");
                return View(model);
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Rol creado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            // Proteger renombre del rol Administrador: solo SuperAdministrador
            if (role.Name == ProtectedRoleName && !IsSuperAdmin())
                return Deny("No tienes permisos para editar el rol Administrador.");

            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!
            };

            return View(model);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, RoleViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            if (role.Name == ProtectedRoleName && !IsSuperAdmin())
                return Deny("No tienes permisos para editar el rol Administrador.");

            var existingRole = await _roleManager.FindByNameAsync(model.Name);
            if (existingRole != null && existingRole.Id != role.Id)
            {
                ModelState.AddModelError(string.Empty, "Ya existe otro rol con ese nombre.");
                return View(model);
            }

            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Rol actualizado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            // Nadie excepto SuperAdministrador puede borrar el rol Administrador
            if (role.Name == ProtectedRoleName && !IsSuperAdmin())
                return Deny("No tienes permisos para eliminar el rol Administrador.");

            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);

            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!,
                UsersCount = usersInRole.Count
            };

            return View(model);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            if (role.Name == ProtectedRoleName && !IsSuperAdmin())
                return Deny("No tienes permisos para eliminar el rol Administrador.");

            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);
            if (usersInRole.Any())
            {
                ModelState.AddModelError(string.Empty, "No se puede eliminar un rol que tiene usuarios asignados.");
                var vm = new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name!,
                    UsersCount = usersInRole.Count
                };
                return View("Delete", vm);
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Rol eliminado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!
            };

            return View("Delete", model);
        }

        // GET: Roles/ManagePermissions/5
        public async Task<IActionResult> ManagePermissions(string id)
        {
            if (id == null)
                return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            // ✅ Aquí NO negamos el acceso al rol Administrador.
            // Solo controlamos qué se puede hacer (solo-add para Admin normal).
            var onlyAddMode = (role.Name == ProtectedRoleName) && !IsSuperAdmin();

            var roleClaims = await _roleManager.GetClaimsAsync(role);

            var model = new ManageRolePermissionsViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name!,
                OnlyAddMode = onlyAddMode
            };

            foreach (var perm in Permissions.All)
            {
                bool alreadyHas = roleClaims.Any(c => c.Type == "permission" && c.Value == perm);

                model.Permissions.Add(new PermissionSelectionViewModel
                {
                    Name = perm,
                    IsSelected = alreadyHas,
                    DisplayName = perm.Replace(".", " - "),
                    IsLocked = onlyAddMode && alreadyHas // ✅ si ya existe, no se puede desmarcar
                });
            }

            return View(model);
        }

        // POST: Roles/ManagePermissions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePermissions(ManageRolePermissionsViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
                return NotFound();

            var currentClaims = await _roleManager.GetClaimsAsync(role);

            var currentPermissions = currentClaims
                .Where(c => c.Type == "permission")
                .Select(c => c.Value)
                .ToList();

            var selectedPermissions = model.Permissions
                .Where(p => p.IsSelected)
                .Select(p => p.Name)
                .ToList();

            bool isProtectedAdminRole = role.Name == ProtectedRoleName;
            bool onlyAddMode = isProtectedAdminRole && !IsSuperAdmin();

            // ❌ Quitar: SOLO si está permitido
            if (!onlyAddMode)
            {
                var toRemove = currentPermissions
                    .Where(p => !selectedPermissions.Contains(p))
                    .ToList();

                foreach (var perm in toRemove)
                {
                    var claim = currentClaims.First(c => c.Type == "permission" && c.Value == perm);
                    await _roleManager.RemoveClaimAsync(role, claim);
                }
            }

            // ✅ Añadir: SIEMPRE permitido
            var toAdd = selectedPermissions
                .Where(p => !currentPermissions.Contains(p))
                .ToList();

            foreach (var perm in toAdd)
            {
                await _roleManager.AddClaimAsync(role, new Claim("permission", perm));
            }

            TempData["SuccessMessage"] = onlyAddMode
                ? "Permisos agregados al rol Administrador (no se permite quitar permisos existentes)."
                : "Permisos del rol actualizados correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}
