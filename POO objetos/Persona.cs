using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Persona
    {
        // Propiedades
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        // Constructor
        public Persona(string nombre, int edad, string genero, string telefono)
        {
            Nombre = nombre;
            Edad = edad;
            Genero = genero;
            Telefono = telefono;
        }

        // Método para imprimir los detalles
        public void ImprimirDetalles()
        {
            Console.WriteLine("\n--- Detalles de la persona ---");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Género: {Genero}");
            Console.WriteLine($"Teléfono: {Telefono}");
        }

        // Método para calcular la edad en días
        public void CalcularEdadEnDias()
        {
            int edadDias = Edad * 365;
            Console.WriteLine($"\nLa edad de {Nombre} en días es: {edadDias} días.");
        }

        // Método para editar la información
        public void EditarInformacion()
        {
            Console.Write("\nNuevo nombre: ");
            Nombre = Console.ReadLine();

            Console.Write("Nueva edad: ");
            Edad = int.Parse(Console.ReadLine());

            Console.Write("Nuevo género (F o M): ");
            Genero = Console.ReadLine();

            Console.Write("Nuevo teléfono: ");
            Telefono = Console.ReadLine();

            Console.WriteLine("\nInformación actualizada con éxito ");
        }
    }
}
