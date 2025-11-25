using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string Nombre { get; set; } = null!;

    [StringLength(250, ErrorMessage = "Máximo 250 caracteres")]
    public string? Descripcion { get; set; }

    [Range(1, 999999, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    public int Stock { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
