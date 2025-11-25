using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Aprendiz
    {
        public string Nombre { get; set; }
        public ProgramaAcademico Programa { get; set; }
        public string FormaPago { get; set; } // "Efectivo" o "Línea"

        public Aprendiz(string nombre, ProgramaAcademico programa, string formaPago)
        {   
            Nombre = nombre;
            Programa = programa;
            FormaPago = formaPago;
        }

        public double CalcularValorPago()
        {
            const double valorCredito = 200000;
            double total = Programa.Creditos * valorCredito;

            if (FormaPago.ToLower() == "efectivo")
                total -= total * Programa.Descuento;

            return total;
        }

        public double CalcularDescuento()
        {
            const double valorCredito = 200000;
            if (FormaPago.ToLower() == "efectivo")
                return Programa.Creditos * valorCredito * Programa.Descuento;

            return 0;
        }
    }
}
