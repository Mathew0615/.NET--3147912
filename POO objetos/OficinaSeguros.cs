using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class OficinaSeguros
    {
        private List<Conductor> conductores = new List<Conductor>();

        public void AgregarConductor(Conductor c)
        {
            conductores.Add(c);
        }

        public double PorcentajeMenoresDe30()
        {
            int menores = conductores.Count(c => c.CalcularEdad() < 30);
            return (double)menores / conductores.Count * 100;
        }

        public double PorcentajeMasculino()
        {
            int hombres = conductores.Count(c => c.Sexo == 2);
            return (double)hombres / conductores.Count * 100;
        }

        public double PorcentajeFemenino()
        {
            int mujeres = conductores.Count(c => c.Sexo == 1);
            return (double)mujeres / conductores.Count * 100;
        }

        public double PorcentajeHombresEntre12y30()
        {
            int hombres1230 = conductores.Count(c => c.Sexo == 2 && c.CalcularEdad() >= 12 && c.CalcularEdad() <= 30);
            return (double)hombres1230 / conductores.Count * 100;
        }

        public double PorcentajeCarrosFueraBogota()
        {
            int fuera = conductores.Count(c => c.RegistroCarro == 2);
            return (double)fuera / conductores.Count * 100;
        }

        public void MostrarResultados()
        {
            Console.WriteLine("\n=== RESULTADOS ===");
            Console.WriteLine($"Porcentaje de conductores menores de 30 años: {PorcentajeMenoresDe30():F2}%");
            Console.WriteLine($"Porcentaje de conductores masculinos: {PorcentajeMasculino():F2}%");
            Console.WriteLine($"Porcentaje de conductores femeninos: {PorcentajeFemenino():F2}%");
            Console.WriteLine($"Porcentaje de conductores masculinos entre 12 y 30 años: {PorcentajeHombresEntre12y30():F2}%");
            Console.WriteLine($"Porcentaje de conductores con carros registrados fuera de Bogotá: {PorcentajeCarrosFueraBogota():F2}%");
        }
    }
}
