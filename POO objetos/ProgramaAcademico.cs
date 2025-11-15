using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class ProgramaAcademico
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public double Descuento { get; set; } 

        public ProgramaAcademico(string nombre, int creditos, double descuento)
        {
            Nombre = nombre;
            Creditos = creditos;
            Descuento = descuento;
        }
    }
}
