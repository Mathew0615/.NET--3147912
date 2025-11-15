using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasdeControl
{
    internal class Program
    {
        static void Main(string[] args) //punto inicio
        {
            //tipos de datos
            //int numero1 = 17;
            //string nombre = "garzón"; // siempre comilas dobles
            //char letra = 'l'; // siempre comillas simples
            //decimal precio = 3.14m; // siempre m al final
            //float altura = 1.75f; // siempre f al final
            //bool esverdadero = true;
            //datetime fecha = datetime.now;


            //Ejercicio #1
            //Console.WriteLine("ingrese su nota 1: ");
            //float nota1 = float.Parse(Console.ReadLine());
            //Console.WriteLine("ingrese su nota 2: ");
            //float nota2 = float.Parse(Console.ReadLine());
            //Console.WriteLine("ingrese su nota 3: ");
            //float nota3 = float.Parse(Console.ReadLine());

            //float promedio = (nota1 * 0.2f) + (nota2 * 0.3f) + (nota3 * 0.5f);
            //if (promedio >= 3)
            //{
            //    Console.WriteLine("aprobado");
            //}
            //else
            //{
            //    Console.WriteLine("reprobado");
            //}


            //ejercicio#2

            //Console.WriteLine("Ingrese el precio del producto: ");
            //float precio = float.Parse(Console.ReadLine());

            //if (precio >= 100000)
            //{
            //    float descuento = precio * 0.10f;
            //    float total = precio - descuento;
            //    Console.WriteLine("Se aplicó un 10% de descuento.");
            //    Console.WriteLine("El precio final es: " + total);
            //}
            //else
            //{
            //    Console.WriteLine("No se aplica descuento.");
            //    Console.WriteLine("El precio final es: " + precio);
            //}



            //prestamo del estudiante

            //Console.WriteLine("Ingrese el monto del préstamo: ");
            //float monto = float.Parse(Console.ReadLine());

            //float interesAnual = monto * 0.05f;
            //float interesTrimestre = interesAnual / 4;
            //float interesMes = interesAnual / 12;

            //float totalPagar = monto + (interesAnual * 5);

            //Console.WriteLine("Interes pagado en un año: " + interesAnual);
            //Console.WriteLine("Interes pagado en el tercer trimestre: " + interesTrimestre);
            //Console.WriteLine("Interes pagado en el primer mes: " + interesMes);
            //Console.WriteLine("Total a pagar incluyendo intereses: " + totalPagar);




            //ejercio #2
            //Console.WriteLine("=== COLILLA DE PAGO ===\n");

            //// Entrada de datos
            //Console.Write("Ingrese el salario del empleado: ");
            //decimal salario = Convert.ToDecimal(Console.ReadLine());

            //Console.Write("Ingrese el valor de ahorro mensual programado: ");
            //decimal ahorro = Convert.ToDecimal(Console.ReadLine());

            //// Cálculos
            //decimal eps = salario * 0.125m;     // 12.5%
            //decimal pension = salario * 0.16m;  // 16%
            //decimal totalRecibir = salario - (eps + pension + ahorro);

            //// Salida
            //Console.WriteLine("\n--- DETALLE DE PAGO ---");
            //Console.WriteLine($"Salario base:               $q  {salario:N2}");
            //Console.WriteLine($"Ahorro mensual programado:  ${ahorro:N2}");
            //Console.WriteLine($"Descuento EPS (12.5%):      ${eps:N2}");
            //Console.WriteLine($"Descuento Pensión (16%):    ${pension:N2}");
            //Console.WriteLine("-------------------------------");
            //Console.WriteLine($"TOTAL A RECIBIR:            ${totalRecibir:N2}");







            //ejercico #3
            //Console.Write("Ingrese el valor total de la matrícula: ");
            //decimal matricula = Convert.ToDecimal(Console.ReadLine());

            //// Cálculos de las cuotas
            //decimal cuota1 = matricula * 0.40m; 
            //decimal cuota2 = matricula * 0.25m; 
            //decimal cuota3 = matricula * 0.20m;  
            //decimal cuota4 = matricula * 0.15m; 

            //// Salida
            //Console.WriteLine("\n--- DETALLE DE PAGOS ---");
            //Console.WriteLine($"Primera cuota (40%):  ${cuota1:N2}");
            //Console.WriteLine($"Segunda cuota (25%):  ${cuota2:N2}");
            //Console.WriteLine($"Tercera cuota (20%):  ${cuota3:N2}");
            //Console.WriteLine($"Cuarta cuota (15%):   ${cuota4:N2}");
            //Console.WriteLine("-------------------------------");
            //Console.WriteLine($"TOTAL MATRÍCULA:      ${matricula:N2}");

            //Console.WriteLine("\nPresione una tecla para salir...");
            //Console.ReadKey();





            // ejercicio #4
            //Console.Write("Ingrese el nombre del aprendiz: ");
            //string nombre = Console.ReadLine();

            //Console.Write("Ingrese la dirección del aprendiz: ");
            //string direccion = Console.ReadLine();

            //Console.Write("Ingrese el año de nacimiento del aprendiz: ");
            //int anioNacimiento = Convert.ToInt32(Console.ReadLine());

            //// Cálculo de la edad
            //int anioActual = DateTime.Now.Year;
            //int edad = anioActual - anioNacimiento;

            //// Salida de la información
            //Console.WriteLine("\n--- INFORMACIÓN COMPLETA ---");
            //Console.WriteLine($"Nombre: {nombre}");
            //Console.WriteLine($"Dirección: {direccion}");
            //Console.WriteLine($"Año de nacimiento: {anioNacimiento}");
            //Console.WriteLine($"Edad: {edad} años");




            //ejercicio #5
            // cuando se conoce 
            //Console.WriteLine("=== TIEMPO DE LLENADO DE BALDES ===\n");

            //// Datos base
            //double tiempoPorLitro = 1.5; // 1.5 horas por litro (del balde de 1 litro)

            //// Baldes conocidos
            //double balde1 = 5;
            //double balde2 = 3;
            //double balde3 = 1;

            //// Cálculo de tiempos
            //double tiempo1 = balde1 * tiempoPorLitro;
            //double tiempo2 = balde2 * tiempoPorLitro;
            //double tiempo3 = balde3 * tiempoPorLitro;

            //// Mostrar resultados
            //Console.WriteLine($"Balde de {balde1} litros se llena en: {tiempo1} horas");
            //Console.WriteLine($"Balde de {balde2} litros se llena en: {tiempo2} horas");
            //Console.WriteLine($"Balde de {balde3} litro  se llena en: {tiempo3} horas")
            ;

            // si se desconoce 
            //double tiempoPorLitro = 1.5;

            //// Ingreso de tamaños
            //Console.Write("Ingrese los litros del balde 1: ");
            //double balde1 = Convert.ToDouble(Console.ReadLine());

            //Console.Write("Ingrese los litros del balde 2: ");
            //double balde2 = Convert.ToDouble(Console.ReadLine());

            //Console.Write("Ingrese los litros del balde 3: ");
            //double balde3 = Convert.ToDouble(Console.ReadLine());

            //// Cálculo
            //double tiempo1 = balde1 * tiempoPorLitro;
            //double tiempo2 = balde2 * tiempoPorLitro;
            //double tiempo3 = balde3 * tiempoPorLitro;

            //// Resultado
            //Console.WriteLine("\n--- RESULTADOS ---");
            //Console.WriteLine($"Balde 1 ({balde1} L): {tiempo1} horas");
            //Console.WriteLine($"Balde 2 ({balde2} L): {tiempo2} horas");
            //Console.WriteLine($"Balde 3 ({balde3} L): {tiempo3} horas");







            //ejercicio #6
            //Console.WriteLine("=== SUBIDA A LA MONTAÑA ===\n");

            //// Datos base
            //double alturaBase = 7;   // metros
            //double tiempoBase = 5;   // horas

            //// Pedir al usuario la altura deseada
            //Console.Write("Ingrese la altura (en metros) que desea subir: ");
            //double alturaDeseada = Convert.ToDouble(Console.ReadLine());

            //// Calcular el tiempo usando regla de tres
            //double tiempoNecesario = (alturaDeseada * tiempoBase) / alturaBase;

            //// Mostrar resultado
            //Console.WriteLine($"\nPara subir {alturaDeseada} metros, el escalador tarda aproximadamente {tiempoNecesario:N2} horas.");







            //ejercicio #7
            Console.Write("Ingrese el monto del préstamo: ");
            decimal prestamo = Convert.ToDecimal(Console.ReadLine());

            decimal tasa = 0.05m;   // 5% anual
            int años = 5;

            decimal interesAnual = prestamo * tasa;
            decimal interesTrimestre = interesAnual / 4;
            decimal interesMes = interesAnual / 12;
            decimal totalPagar = prestamo + (interesAnual * años);

            Console.WriteLine($"\nDinero pagado en un año: ${interesAnual:N2}");
            Console.WriteLine($"Interés en el tercer trimestre: ${interesTrimestre:N2}");
            Console.WriteLine($"Interés en el primer mes: ${interesMes:N2}");
            Console.WriteLine($"Total a pagar en {años} años (incluye intereses): ${totalPagar:N2}");

        }
    }
}
