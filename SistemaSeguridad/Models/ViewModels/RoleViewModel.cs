    using System.ComponentModel.DataAnnotations;

    namespace SistemaSeguridad.Models.ViewModels
    {
        /// <summary>
        /// Vista para listar / crear / editar roles.
        /// </summary>
        public class RoleViewModel
        {
            public string? Id { get; set; }

            [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
            [Display(Name = "Nombre del rol")]
            [StringLength(100, ErrorMessage = "El nombre del rol no puede superar los {1} caracteres.")]
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// Cantidad de usuarios que actualmente tienen este rol.
            /// Solo se usa para mostrar en la vista, no se guarda en BD.
            /// </summary>
            [Display(Name = "Usuarios asignados")]
            public int UsersCount { get; set; }
        }
    }
