using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Auto //clase Auto
    {
        //atributos
        public string Marca{ get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }

        public string Color { get; set; }

        //constructor
        public Auto(string marca, string modelo, int año, string color)
        {
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Color = color;
        }
        //metodos
        public void Mostrar_info ()
        {
            Console.WriteLine($"marca: {Marca},  año: {Año},  modelo:{Modelo} y color: {Color}");
        }




    }
}
