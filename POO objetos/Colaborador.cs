using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Colaborador
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public int Edad
        {
            get
            {
                int edad = DateTime.Now.Year - FechaNacimiento.Year;
                if (DateTime.Now < FechaNacimiento.AddYears(edad)) edad--;
                return edad;
            }
        }

        public int MesCumple => FechaNacimiento.Month;
    }
}
