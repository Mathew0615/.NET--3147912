using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models;

public partial class DetalleVenta
{
    public int DetalleId { get; set; }

    [Required]
    public int VentaId { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
    public int Cantidad { get; set; }

    [Range(1, 999999, ErrorMessage = "Precio inválido")]
    public decimal PrecioUnitario { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Venta Venta { get; set; } = null!;
}
