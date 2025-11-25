using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Camion
    {
        public int Id { get; private set; }
        public int Capacidad { get; private set; } // litros
        public int CargaActual { get; private set; } // litros

        public Camion(int id, int capacidad)
        {
            Id = id;
            Capacidad = capacidad;
            CargaActual = 0;
        }

        public bool PuedeCargar(int volumen)
        {
            return CargaActual + volumen <= Capacidad;
        }

        public void Cargar(int volumen)
        {
            if (!PuedeCargar(volumen))
                throw new InvalidOperationException("No cabe la carga en el camión.");
            CargaActual += volumen;
        }

        public override string ToString()
        {
            return $"Camión #{Id} - Capacidad: {Capacidad} L, Cargado: {CargaActual} L";
        }
    }
}
