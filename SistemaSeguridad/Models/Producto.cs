using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaSeguridad.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Nombre del producto")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Precio")]
        [Range(0, 999999999)]
        public decimal Precio { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; } = true;
    }
}
