using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoCrudMathew.Models;

namespace Proyecto_crud_mathew.Data
{
    public class Proyecto_crud_mathewContext : DbContext
    {
        public Proyecto_crud_mathewContext(DbContextOptions<Proyecto_crud_mathewContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<Venta> Venta { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Venta>().ToTable("Ventas");

            base.OnModelCreating(modelBuilder);
        }
    }
}
