using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaSeguridad.Models.ViewModels
{
    /// <summary>
    /// Vista para listar usuarios con información de seguridad y sus roles.
    /// </summary>
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Usuario")]
        public string? UserName { get; set; }

        [Display(Name = "Correo confirmado")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Bloqueo habilitado")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Bloqueado hasta")]
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Indica si el usuario está actualmente bloqueado.
        /// </summary>
        [Display(Name = "¿Está bloqueado?")]
        public bool IsLockedOut
        {
            get
            {
                return LockoutEnd.HasValue && LockoutEnd.Value.UtcDateTime > DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Lista de roles que tiene el usuario.
        /// </summary>
        public IList<string> Roles { get; set; } = new List<string>();

        /// <summary>
        /// Roles formateados para mostrar en tabla.
        /// </summary>
        [Display(Name = "Roles")]
        public string RolesDisplay => Roles != null && Roles.Count > 0
            ? string.Join(", ", Roles)
            : "Sin roles";
    }
}
