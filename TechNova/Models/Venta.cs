using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un cliente")]
    public int ClienteId { get; set; }

    public DateTime FechaVenta { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
