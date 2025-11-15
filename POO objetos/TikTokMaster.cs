using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class TikTokMaster
    {
        private const int BONO = 150000;
        private List<Colaborador> colaboradores = new List<Colaborador>();

        public void AgregarColaborador(Colaborador c)
        {
            colaboradores.Add(c);
        }

        public List<Colaborador> ObtenerColaboradoresValidos()
        {
            return colaboradores.Where(c => c.Edad >= 18 && c.Edad < 50).ToList();
        }

        public double CalcularPromedioEdad()
        {
            var validos = ObtenerColaboradoresValidos();
            return validos.Count > 0 ? validos.Average(c => c.Edad) : 0;
        }

        public void MostrarReporte()
        {
            var validos = ObtenerColaboradoresValidos();
            if (validos.Count == 0)
            {
                Console.WriteLine("\nNo hay colaboradores válidos para recibir bono.");
                return;
            }

            Console.WriteLine($"\n📊 Promedio de edad: {CalcularPromedioEdad():0.0} años");
            Console.WriteLine("\n=== LISTA DESGLOSADA POR MESES ===\n");

            int totalGeneral = 0;

            for (int mes = 1; mes <= 12; mes++)
            {
                var cumpleMes = validos.Where(c => c.MesCumple == mes).ToList();
                int cantidad = cumpleMes.Count;
                int totalMes = cantidad * BONO;
                totalGeneral += totalMes;

                if (cantidad > 0)
                {
                    Console.WriteLine($"Mes: {NombreMes(mes)}");
                    Console.WriteLine($"  Colaboradores: {cantidad}");
                    Console.WriteLine($"  Total en bonos: ${totalMes:N0}\n");
                }
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Total colaboradores con bono: {validos.Count}");
            Console.WriteLine($"Total dinero en bonificaciones: ${totalGeneral:N0}\n");

            var sinBono = colaboradores.Except(validos).ToList();
            if (sinBono.Count > 0)
            {
                Console.WriteLine("Colaboradores sin bono (por edad):");
                foreach (var c in sinBono)
                {
                    Console.WriteLine($"- {c.Nombre} ({c.Edad} años)");
                }
            }
        }

        private string NombreMes(int mes)
        {
            string[] nombres = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                                 "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            return nombres[mes - 1];
        }
    }
}
