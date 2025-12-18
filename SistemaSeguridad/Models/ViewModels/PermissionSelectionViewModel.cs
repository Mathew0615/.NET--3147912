using System.ComponentModel.DataAnnotations;

namespace SistemaSeguridad.Models.ViewModels
{
    /// <summary>
    /// Representa un permiso individual que se puede asignar o quitar a un rol.
    /// </summary>
    public class PermissionSelectionViewModel
    {
        /// <summary>
        /// Nombre interno del permiso (ej: "Productos.Crear", "Reportes.Ver").
        /// </summary>
        [Required]
        [Display(Name = "Permiso")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Indica si el permiso está actualmente asignado al rol.
        /// </summary>
        [Display(Name = "Asignado")]
        public bool IsSelected { get; set; }

        /// <summary>
        /// Texto amigable para mostrar en la vista (opcional).
        /// Si no lo usas, puedes omitirlo.
        /// </summary>
        [Display(Name = "Descripción")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// ✅ Si está true, el permiso ya existía y NO se permite desmarcar (solo SuperAdministrador puede).
        /// </summary>
        public bool IsLocked { get; set; }
    }
}
