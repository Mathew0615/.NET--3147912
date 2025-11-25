using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> numeros = new List<int>();
            //numeros.Add(10);
            //numeros.Add(20);
            //numeros.Add(30);
            //Console.WriteLine("Numeros en la lista:");
            //foreach (int item in numeros)
            //{
            //    Console.WriteLine(item);
            //}
            ////Acceder a un elemento por su indice
            //int primerNumero = numeros[1];
            //Console.WriteLine($"El numero en la lista es: {primerNumero}");

            ////Modificar un elemento en la lista
            //numeros[2] = 50;
            //Console.WriteLine($"Numero modificado: { numeros}");

            ////insertar un elemento en un posicion especifica
            //numeros.Insert(2, 15);
            //Console.WriteLine($"Numero modificad: {numeros[2]}");

            ////Eliminar un elemento de la lista especifica
            //numeros.RemoveAt(1);//elimina la posicion 1

            ////Eliminar un elemento por su valor 
            //numeros.Remove(10);//Elimina el valor 10







            //__________Ejercicio 1____________

            List<string> productos = new List<string>();
            List<double> precios = new List<double>();

            productos.Add("Arroz");
            precios.Add(2500);

            productos.Add("Leche");
            precios.Add(3600);

            productos.Add("pan");
            precios.Add(3000);

            Console.WriteLine("Lista de productos:");
            for (int i = 0; 1 < productos.Count; i++)
            {
                Console.WriteLine(productos[i] + " - $" + precios[i]);
            }
        }
    }
}
