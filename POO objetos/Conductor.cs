using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Conductor
    {
        public int AnioNacimiento { get; set; }
        public int Sexo { get; set; } // 1: Femenino, 2: Masculino
        public int RegistroCarro { get; set; } // 1: Bogotá, 2: Otras ciudades

        public Conductor(int anioNacimiento, int sexo, int registroCarro)
        {
            AnioNacimiento = anioNacimiento;
            Sexo = sexo;
            RegistroCarro = registroCarro;
        }

        public int CalcularEdad()
        {
            return DateTime.Now.Year - AnioNacimiento;
        }
    }
}
