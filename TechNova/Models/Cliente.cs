using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
    [StringLength(150)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string? Telefono { get; set; }

    [StringLength(200)]
    public string? Direccion { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
