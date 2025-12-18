using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaSeguridad.Models.ViewModels
{
    /// <summary>
    /// Modelo para la pantalla donde se gestionan los permisos de un rol concreto.
    /// </summary>
    public class ManageRolePermissionsViewModel
    {
        [Required]
        public string RoleId { get; set; } = string.Empty;

        [Display(Name = "Rol")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// ✅ Si es true, el usuario solo puede AGREGAR permisos, no QUITAR los ya existentes.
        /// (Se usa para el rol Administrador cuando NO es SuperAdministrador.)
        /// </summary>
        public bool OnlyAddMode { get; set; }

        /// <summary>
        /// Lista de todos los permisos posibles, marcados o no.
        /// </summary>
        public List<PermissionSelectionViewModel> Permissions { get; set; } = new();
    }
}
