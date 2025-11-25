using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class CentralDistribucion
    {
        private const int MAX_CAMIONES = 20;
        private List<Camion> despachados = new List<Camion>();
        public Camion CamionActual { get; private set; }
        private int siguienteId = 1;

        public IReadOnlyList<Camion> Despachados => despachados.AsReadOnly();

        public bool TieneCupo => despachados.Count < MAX_CAMIONES;

        // Crear un nuevo camión para comenzar a cargar (operario define la capacidad)
        public void IniciarNuevoCamion(int capacidad)
        {
            if (!TieneCupo)
                throw new InvalidOperationException("Se alcanzó el máximo de camiones diarios.");
            CamionActual = new Camion(siguienteId++, capacidad);
        }

        // Procesa una saca; devuelve mensaje con la acción tomada
        public string ProcesarSaca(int volumen)
        {
            if (CamionActual == null)
                return "No hay camión en carga. Debe iniciar uno primero.";

            // caso: saca más grande que la capacidad total del camión (imposible)
            if (volumen > CamionActual.Capacidad)
            {
                return $"ERROR: La saca ({volumen} L) supera la capacidad del camión ({CamionActual.Capacidad} L). Debe dividir la saca.";
            }

            // si cabe en el camión actual: cargar
            if (CamionActual.PuedeCargar(volumen))
            {
                CamionActual.Cargar(volumen);
                return $"Cargada {volumen} L en {CamionActual}.";
            }
            else
            {
                // despachar camión actual
                despachados.Add(CamionActual);
                string despachoMsg = $"Despachado: {CamionActual}.";

                // si ya no hay cupo para otro camión
                if (!TieneCupo)
                {
                    CamionActual = null;
                    return despachoMsg + " Se alcanzó el máximo de camiones diarios. La saca no fue procesada.";
                }

                // necesita que el operario inicie un nuevo camión con capacidad
                CamionActual = null;
                return despachoMsg + " Inicie el siguiente camión para intentar cargar la saca.";
            }
        }

        // Llamar cuando el operario confirma nueva capacidad y quiere intentar de nuevo
        public string IntentarCargarEnNuevoCamion(int capacidad, int volumen)
        {
            IniciarNuevoCamion(capacidad);

            if (volumen > CamionActual.Capacidad)
            {
                return $"ERROR: la saca ({volumen} L) sigue siendo mayor que la nueva capacidad ({CamionActual.Capacidad} L). Debe dividirse.";
            }

            CamionActual.Cargar(volumen);
            return $"Cargada {volumen} L en {CamionActual}.";
        }

        // Finalizar turno: si hay camión en proceso y tiene carga, lo podemos despachar como parcial
        public void DespacharParcialSiHay()
        {
            if (CamionActual != null && CamionActual.CargaActual > 0 && TieneCupo)
            {
                despachados.Add(CamionActual);
                CamionActual = null;
            }
        }

        // Resumen
        public string Resumen()
        {
            int totalLitros = 0;
            foreach (var c in despachados) totalLitros += c.CargaActual;

            string resumen = $"Camiones despachados: {despachados.Count}\nTotal litros despachados: {totalLitros} L\n";
            resumen += "Detalle:\n";
            foreach (var c in despachados) resumen += c + "\n";
            if (CamionActual != null) resumen += "Camión en proceso: " + CamionActual + "\n";
            return resumen;
        }
    }
}
