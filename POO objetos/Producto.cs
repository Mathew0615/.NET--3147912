using System;
using System.Collections.Generic;

namespace POO_objetos
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }
    }

    internal class ProductoCrud
    {
        public List<Producto> productos = new List<Producto>();
        public int siguienteId = 1;

        // Crear
        public void AgregarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto: ");
            decimal precio;
            while (!decimal.TryParse(Console.ReadLine(), out precio))
            {
                Console.WriteLine("Precio inválido. Intente de nuevo:");
            }

            Producto nuevoProducto = new Producto(siguienteId++, nombre, precio);
            productos.Add(nuevoProducto);
            Console.WriteLine("Producto agregado correctamente\n");
        }

        // Leer
        public void MostrarProductos()
        {
            Console.WriteLine("\n Lista de productos:");
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.\n");
                return;
            }

            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: ${producto.Precio}");
            }
            Console.WriteLine();
        }

        // Actualizar
        public void ActualizarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a actualizar:");
            int idActualizar;
            if (!int.TryParse(Console.ReadLine(), out idActualizar))
            {
                Console.WriteLine("ID inválido.\n");
                return;
            }

            var producto = productos.Find(p => p.Id == idActualizar);
            if (producto != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del producto:");
                producto.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo precio del producto:");
                decimal nuevoPrecio;
                while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio))
                {
                    Console.WriteLine("Precio inválido. Intente de nuevo:");
                }

                producto.Precio = nuevoPrecio;
                Console.WriteLine("✅ Producto actualizado correctamente\n");
            }
            else
            {
                Console.WriteLine("❌ Producto no encontrado.\n");
            }
        }

        // Eliminar
        public void EliminarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a eliminar:");
            int idEliminar;
            if (!int.TryParse(Console.ReadLine(), out idEliminar))
            {
                Console.WriteLine("ID inválido.\n");
                return;
            }

            var producto = productos.Find(p => p.Id == idEliminar);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine(" Producto eliminado correctamente.\n");
            }
            else
            {
                Console.WriteLine(" Producto no encontrado.\n");
            }
        }
    }
}