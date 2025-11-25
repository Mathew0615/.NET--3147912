using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechNova.Models;

namespace TechNova.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class VentasController : Controller
    {
        private readonly TechNovaContext _context;

        public VentasController(TechNovaContext context)
        {
            _context = context;
        }

        // GET: Ventas (CON BUSCADOR)
        public async Task<IActionResult> Index(string searchCliente, DateTime? searchFecha)
        {
            ViewData["CurrentFilterCliente"] = searchCliente;
            ViewData["CurrentFilterFecha"] = searchFecha?.ToString("yyyy-MM-dd");

            var ventas = _context.Ventas.Include(v => v.Cliente).AsQueryable();

            if (!String.IsNullOrEmpty(searchCliente))
            {
                ventas = ventas.Where(v => v.Cliente.Nombre.Contains(searchCliente));
            }

            if (searchFecha.HasValue)
            {
                ventas = ventas.Where(v => v.FechaVenta.Date == searchFecha.Value.Date);
            }

            return View(await ventas.ToListAsync());
        }

        // GET: Ventas/Details/5 (CON DESGLOSE COMPLETO)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (venta == null)
            {
                return NotFound();
            }

            // Calcular total
            ViewBag.Total = venta.DetalleVenta.Sum(d => d.Cantidad * d.PrecioUnitario);

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            ViewData["Productos"] = new SelectList(_context.Productos.Where(p => p.Stock > 0), "ProductoId", "Nombre");
            return View();
        }

        // POST: Ventas/Create (CON VALIDACIÓN Y ACTUALIZACIÓN DE STOCK)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ClienteId, int[] ProductoIds, int[] Cantidades)
        {
            if (ProductoIds == null || Cantidades == null || ProductoIds.Length == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto");
                ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ClienteId);
                ViewData["Productos"] = new SelectList(_context.Productos.Where(p => p.Stock > 0), "ProductoId", "Nombre");
                return View();
            }

            // VALIDAR STOCK SUFICIENTE
            for (int i = 0; i < ProductoIds.Length; i++)
            {
                var producto = await _context.Productos.FindAsync(ProductoIds[i]);
                if (producto == null)
                {
                    ModelState.AddModelError("", $"Producto no encontrado");
                    ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ClienteId);
                    ViewData["Productos"] = new SelectList(_context.Productos.Where(p => p.Stock > 0), "ProductoId", "Nombre");
                    return View();
                }

                if (producto.Stock < Cantidades[i])
                {
                    ModelState.AddModelError("", $"Stock insuficiente para {producto.Nombre}. Solo hay {producto.Stock} unidades disponibles");
                    ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ClienteId);
                    ViewData["Productos"] = new SelectList(_context.Productos.Where(p => p.Stock > 0), "ProductoId", "Nombre");
                    return View();
                }
            }

            // CREAR LA VENTA
            var venta = new Venta
            {
                ClienteId = ClienteId,
                FechaVenta = DateTime.Now
            };
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            // CREAR DETALLES Y ACTUALIZAR STOCK
            for (int i = 0; i < ProductoIds.Length; i++)
            {
                var producto = await _context.Productos.FindAsync(ProductoIds[i]);

                var detalle = new DetalleVenta
                {
                    VentaId = venta.VentaId,
                    ProductoId = producto.ProductoId,
                    Cantidad = Cantidades[i],
                    PrecioUnitario = producto.Precio
                };
                _context.DetalleVentas.Add(detalle);

                // ⚠️ ACTUALIZAR STOCK AUTOMÁTICAMENTE
                producto.Stock -= Cantidades[i];
                _context.Update(producto);
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Venta registrada exitosamente y stock actualizado";
            return RedirectToAction(nameof(Index));
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaId,ClienteId,FechaVenta")] Venta venta)
        {
            if (id != venta.VentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Venta actualizada exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.VentaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (venta == null)
            {
                return NotFound();
            }

            ViewBag.Total = venta.DetalleVenta.Sum(d => d.Cantidad * d.PrecioUnitario);
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.DetalleVenta)
                .FirstOrDefaultAsync(v => v.VentaId == id);

            if (venta != null)
            {
                // Eliminar primero los detalles
                _context.DetalleVentas.RemoveRange(venta.DetalleVenta);

                // Luego la venta
                _context.Ventas.Remove(venta);

                await _context.SaveChangesAsync();
                TempData["Success"] = "Venta eliminada exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }
    }
}