using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Empleado
    {
        public string Nombre { get; set; }
        public List<double> Ventas { get; set; } = new List<double>();
        public double PagoBasico { get; } = 500000;

        public Empleado(string nombre)
        {
            Nombre = nombre;
        }

        // Contadores por rangos de venta
        public int VentasMenoresIguales300()
        {
            return Ventas.Count(v => v <= 300000);
        }

        public int VentasEntre300y800()
        {
            return Ventas.Count(v => v > 300000 && v < 800000);
        }

        public int VentasMayoresIguales800()
        {
            return Ventas.Count(v => v >= 800000);
        }

        // Total de ventas del empleado
        public double TotalVentas()
        {
            return Ventas.Sum();
        }

        // Calcular porcentaje de bonificación según el total vendido
        public double PorcentajeBonificacion()
        {
            double total = TotalVentas();

            if (total >= 800001)
                return 0.10;
            else if (total > 400000 && total <= 800000)
                return 0.05;
            else if (total >= 400000)
                return 0.03;
            else
                return 0;
        }

        public double CalcularBonificacion()
        {
            return TotalVentas() * PorcentajeBonificacion();
        }

        public double PagoTotal()
        {
            return PagoBasico + CalcularBonificacion();
        }
    }
}
