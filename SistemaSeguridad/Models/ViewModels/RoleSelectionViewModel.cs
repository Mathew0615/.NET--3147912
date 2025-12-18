using System.ComponentModel.DataAnnotations;

namespace SistemaSeguridad.Models.ViewModels
{
    /// <summary>
    /// Representa un rol que puede ser marcado / desmarcado para un usuario.
    /// </summary>
    public class RoleSelectionViewModel
    {
        /// <summary>
        /// Id del rol (IdentityRole.Id).
        /// </summary>
        public string? RoleId { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// Indica si el usuario actualmente tiene este rol.
        /// </summary>
        [Display(Name = "Asignado")]
        public bool IsSelected { get; set; }
    }
}
