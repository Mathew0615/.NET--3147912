using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaSeguridad.Models.ViewModels
{
    /// <summary>
    /// Modelo para gestionar (asignar/quitar) roles de un usuario concreto.
    /// </summary>
    public class ManageUserRolesViewModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Display(Name = "Correo del usuario")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Nombre de usuario")]
        public string? UserName { get; set; }

        public List<RoleSelectionViewModel> Roles { get; set; } = new();
    }
}
