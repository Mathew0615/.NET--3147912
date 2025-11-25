using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            Console.WriteLine("Libro agregado con éxito.\n");
        }

        public void ListarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.\n");
                return;
            }

            Console.WriteLine("Lista de libros:\n");
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
            }
            Console.WriteLine();
        }

        public void BuscarLibroPorTitulo(string titulo)
        {
            var resultado = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (resultado != null)
            {
                Console.WriteLine("Libro encontrado:");
                Console.WriteLine(resultado + "\n");
            }
            else
            {
                Console.WriteLine("❌ No se encontró un libro con ese título.\n");
            }
        }
    }
}
