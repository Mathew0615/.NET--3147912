using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaSeguridad.Data;
using SistemaSeguridad.Models;
using SistemaSeguridad.Security;

namespace SistemaSeguridad.Controllers
{
    [Authorize] // requiere que esté autenticado
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        // Permiso: Productos.Ver
        [Authorize(Policy = Permissions.Productos_Ver)]
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos
                .OrderBy(p => p.Nombre)
                .ToListAsync();

            return View(productos);
        }

        // GET: Productos/Details/5
        [Authorize(Policy = Permissions.Productos_Ver)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // GET: Productos/Create
        [Authorize(Policy = Permissions.Productos_Crear)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Permissions.Productos_Crear)]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Productos/Edit/5
        [Authorize(Policy = Permissions.Productos_Editar)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Permissions.Productos_Editar)]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(producto);

            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.Id == producto.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Productos/Delete/5
        [Authorize(Policy = Permissions.Productos_Eliminar)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Permissions.Productos_Eliminar)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
