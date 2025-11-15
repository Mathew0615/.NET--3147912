using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creamos el objeto auto
            //Auto miAuto = new Auto("Toyota", "Corolla", 2020, "messi");
            //miAuto.Mostrar_info();

            //Auto bus = new Auto("ferrari", "urus", 2025, "negro");
            //bus.Mostrar_info();

            //Auto camion = new Auto("ford", "f-150", 2025, "azul");
            //camion.Mostrar_info();

            //creamos el objeto Estudiante
            //Console.WriteLine("ingrse el nombre del estudainte");
            //string nombre = Console.ReadLine();
            //Console.WriteLine("ingrse la edad del estudainte");
            //int edad = int.Parse(Console.ReadLine());

            //Estudiante estudiante1 = new Estudiante(nombre, edad);
            //estudiante1.VerificarEdad();








            //Producto 
            //ProductoCrud crud = new ProductoCrud();
            //int opcion = 0;

            //do
            //{
            //    Console.WriteLine("===== MENÚ DE PRODUCTOS =====");
            //    Console.WriteLine("1. Agregar producto");
            //    Console.WriteLine("2. Mostrar productos");
            //    Console.WriteLine("3. Actualizar producto");
            //    Console.WriteLine("4. Eliminar producto");
            //    Console.WriteLine("5. Salir");
            //    Console.Write("Seleccione una opción: ");

            //    int.TryParse(Console.ReadLine(), out opcion);
            //    Console.WriteLine();

            //    switch (opcion)
            //    {
            //        case 1:
            //            crud.AgregarProducto();
            //            break;
            //        case 2:
            //            crud.MostrarProductos();
            //            break;
            //        case 3:
            //            crud.ActualizarProducto();
            //            break;
            //        case 4:
            //            crud.EliminarProducto();
            //            break;
            //        case 5:
            //            Console.WriteLine(" Saliendo del programa...");
            //            break;
            //        default:
            //            Console.WriteLine(" Opción no válida.\n");
            //            break;
            //    }

            //} while (opcion != 5);








            // ejercicio con PERSONA 
            //Console.WriteLine("=== PROGRAMA AGENDA ===");

            //// Solicitar datos iniciales
            //Console.Write("Ingrese el nombre: ");
            //string nombre = Console.ReadLine();

            //Console.Write("Ingrese la edad: ");
            //int edad = int.Parse(Console.ReadLine());

            //Console.Write("Ingrese el género (F o M): ");
            //string genero = Console.ReadLine();

            //Console.Write("Ingrese el teléfono: ");
            //string telefono = Console.ReadLine();

            //// Crear el objeto Persona
            //Persona persona = new Persona(nombre, edad, genero, telefono);

            //int opcion;
            //do
            //{
            //    Console.WriteLine("\n--- MENÚ ---");
            //    Console.WriteLine("1. Imprimir detalles");
            //    Console.WriteLine("2. Calcular edad en días");
            //    Console.WriteLine("3. Editar información");
            //    Console.WriteLine("4. Salir");
            //    Console.Write("Seleccione una opción: ");
            //    opcion = int.Parse(Console.ReadLine());

            //    switch (opcion)
            //    {
            //        case 1:
            //            persona.ImprimirDetalles();
            //            break;
            //        case 2:
            //            persona.CalcularEdadEnDias();
            //            break;
            //        case 3:
            //            persona.EditarInformacion();
            //            break;
            //        case 4:
            //            Console.WriteLine("Saliendo del programa...");
            //            break;
            //        default:
            //            Console.WriteLine("Opción no válida, intente de nuevo.");
            //            break;
            //    }
            //} while (opcion != 4);








            ////ADMINISTRACIÓN DE UNA BIBLIOTECA.
            //Biblioteca biblioteca = new Biblioteca();
            //int opcion;

            //do
            //{
            //    Console.WriteLine("=== MENÚ BIBLIOTECA ===");
            //    Console.WriteLine("1. Agregar libro");
            //    Console.WriteLine("2. Listar libros");
            //    Console.WriteLine("3. Buscar libro por título");
            //    Console.WriteLine("4. Salir");
            //    Console.Write("Seleccione una opción: ");

            //    if (!int.TryParse(Console.ReadLine(), out opcion))
            //    {
            //        Console.WriteLine("Opción no válida.\n");
            //        continue;
            //    }

            //    switch (opcion)
            //    {
            //        case 1:
            //            Console.Write("Título: ");
            //            string titulo = Console.ReadLine();

            //            Console.Write("Autor: ");
            //            string autor = Console.ReadLine();

            //            Console.Write("Editorial: ");
            //            string editorial = Console.ReadLine();

            //            Console.Write("Año de publicación: ");
            //            int anio = int.Parse(Console.ReadLine());

            //            Libro nuevoLibro = new Libro(titulo, autor, editorial, anio);
            //            biblioteca.AgregarLibro(nuevoLibro);
            //            break;

            //        case 2:
            //            biblioteca.ListarLibros();
            //            break;

            //        case 3:
            //            Console.Write("Ingrese el título del libro a buscar: ");
            //            string tituloBuscar = Console.ReadLine();
            //            biblioteca.BuscarLibroPorTitulo(tituloBuscar);
            //            break;

            //        case 4:
            //            Console.WriteLine("Saliendo del programa...");
            //            break;

            //        default:
            //            Console.WriteLine("Opción inválida.\n");
            //            break;
            //    }

            //} while (opcion != 4);








            ////Una universidad requiere analizar el proceso de matrícula
            //List<ProgramaAcademico> programas = new List<ProgramaAcademico>()
            //{
            //    new ProgramaAcademico("Ingeniería de Sistemas", 20, 0.18),
            //    new ProgramaAcademico("Psicología", 16, 0.12),
            //    new ProgramaAcademico("Economía", 18, 0.10),
            //    new ProgramaAcademico("Comunicación Social", 18, 0.05),
            //    new ProgramaAcademico("Administración de Empresas", 20, 0.15)
            //};

            //List<Aprendiz> aprendices = new List<Aprendiz>();
            //int cantidad;

            //Console.Write("Ingrese el número de aprendices a matricular: ");
            //cantidad = int.Parse(Console.ReadLine());

            //for (int i = 0; i < cantidad; i++)
            //{
            //    Console.WriteLine($"\n--- Aprendiz {i + 1} ---");
            //    Console.Write("Nombre del aprendiz: ");
            //    string nombre = Console.ReadLine();

            //    Console.WriteLine("Seleccione el programa académico:");
            //    for (int j = 0; j < programas.Count; j++)
            //        Console.WriteLine($"{j + 1}. {programas[j].Nombre}");

            //    int opcion = int.Parse(Console.ReadLine());
            //    ProgramaAcademico programaSeleccionado = programas[opcion - 1];

            //    Console.Write("Forma de pago (Efectivo / Linea): ");
            //    string formaPago = Console.ReadLine();

            //    aprendices.Add(new Aprendiz(nombre, programaSeleccionado, formaPago));
            //    Console.WriteLine("Aprendiz matriculado correctamente.\n");
            //}

            //// Calcular resultados
            //Console.WriteLine("\n=== RESULTADOS ===");
            //const double valorCredito = 200000;

            //// a. Cantidad de aprendices por programa
            //Console.WriteLine("\na) Cantidad de aprendices inscritos por programa:");
            //foreach (var programa in programas)
            //{
            //    int cantidadAprendices = aprendices.Count(a => a.Programa.Nombre == programa.Nombre);
            //    Console.WriteLine($"{programa.Nombre}: {cantidadAprendices}");
            //}

            //// b. Total de créditos inscritos
            //int totalCreditos = aprendices.Sum(a => a.Programa.Creditos);
            //Console.WriteLine($"\nb) Total de créditos inscritos: {totalCreditos}");

            //// c. Valor total sin descuento
            //double totalSinDescuento = totalCreditos * valorCredito;
            //Console.WriteLine($"c) Valor total sin descuento: ${totalSinDescuento:N0}");

            //// d. Valor total de descuentos aplicados
            //double totalDescuentos = aprendices.Sum(a => a.CalcularDescuento());
            //Console.WriteLine($"d) Total de descuentos aplicados: ${totalDescuentos:N0}");

            //// e. Valor neto (con descuentos)
            //double valorNeto = totalSinDescuento - totalDescuentos;
            //Console.WriteLine($"e) Valor neto de inscripciones: ${valorNeto:N0}");








            //La empresa de tecnología “COMPUTRONIC”
            //List<Empleado> empleados = new List<Empleado>();

            //Console.Write("Ingrese el número de empleados: ");
            //int n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"\n--- Empleado {i + 1} ---");
            //    Console.Write("Nombre del empleado: ");
            //    string nombre = Console.ReadLine();

            //    Empleado empleado = new Empleado(nombre);

            //    Console.Write("Ingrese la cantidad de ventas realizadas: ");
            //    int numVentas = int.Parse(Console.ReadLine());

            //    for (int j = 0; j < numVentas; j++)
            //    {
            //        double venta;
            //        do
            //        {
            //            Console.Write($"Valor de la venta #{j + 1}: ");
            //            venta = double.Parse(Console.ReadLine());
            //            if (venta <= 0)
            //                Console.WriteLine("⚠️ El valor debe ser positivo.");
            //        } while (venta <= 0);

            //        empleado.Ventas.Add(venta);
            //    }

            //    empleados.Add(empleado);
            //}

            //Console.WriteLine("\n=== RESULTADOS DEL DÍA ===");

            //foreach (var emp in empleados)
            //{
            //    Console.WriteLine($"\nEmpleado: {emp.Nombre}");
            //    Console.WriteLine($"Ventas menores o iguales a $300.000: {emp.VentasMenoresIguales300()}");
            //    Console.WriteLine($"Ventas mayores a $300.000 y menores a $800.000: {emp.VentasEntre300y800()}");
            //    Console.WriteLine($"Ventas mayores o iguales a $800.000: {emp.VentasMayoresIguales800()}");
            //    Console.WriteLine($"Total ventas realizadas: ${emp.TotalVentas():N0}");
            //    Console.WriteLine($"Porcentaje de bonificación: {emp.PorcentajeBonificacion() * 100}%");
            //    Console.WriteLine($"Valor bonificación: ${emp.CalcularBonificacion():N0}");
            //    Console.WriteLine($"Pago básico: ${emp.PagoBasico:N0}");
            //    Console.WriteLine($" Pago total: ${emp.PagoTotal():N0}");
            //}









            //Una oficina de seguros
            //OficinaSeguros oficina = new OficinaSeguros();

            //Console.Write("Ingrese la cantidad de conductores registrados: ");
            //int cantidad = int.Parse(Console.ReadLine());

            //for (int i = 0; i < cantidad; i++)
            //{
            //    Console.WriteLine($"\n--- Conductor {i + 1} ---");

            //    Console.Write("Año de nacimiento: ");
            //    int anio = int.Parse(Console.ReadLine());

            //    Console.Write("Sexo (1: Femenino, 2: Masculino): ");
            //    int sexo = int.Parse(Console.ReadLine());

            //    Console.Write("Registro del carro (1: Bogotá, 2: Otras ciudades): ");
            //    int registro = int.Parse(Console.ReadLine());

            //    Conductor c = new Conductor(anio, sexo, registro);
            //    oficina.AgregarConductor(c);
            //}

            //oficina.MostrarResultados();








            ////La empresa Tik Tok
            //TikTokMaster sistema = new TikTokMaster();

            //Console.WriteLine("=== SISTEMA DE BONIFICACIONES TIKTOK ===\n");
            //Console.Write("Ingrese la cantidad de colaboradores: ");
            //int cantidad = int.Parse(Console.ReadLine());

            //for (int i = 0; i < cantidad; i++)
            //{
            //    Console.WriteLine($"\nColaborador #{i + 1}");
            //    Console.Write("Nombre: ");
            //    string nombre = Console.ReadLine();

            //    DateTime fechaNacimiento;
            //    while (true)
            //    {
            //        Console.Write("Fecha de nacimiento (AAAA-MM-DD): ");
            //        if (DateTime.TryParse(Console.ReadLine(), out fechaNacimiento) && fechaNacimiento <= DateTime.Now)
            //            break;
            //        Console.WriteLine("❌ Fecha inválida. Intente de nuevo.");
            //    }

            //    sistema.AgregarColaborador(new Colaborador
            //    {
            //        Nombre = nombre,
            //        FechaNacimiento = fechaNacimiento
            //    });
            //}

            //Console.Clear();
            //Console.WriteLine("=== REPORTE FINAL DE BONIFICACIONES ===");
            //sistema.MostrarReporte();

            //Console.WriteLine("\nPresione una tecla para salir...");
            //Console.ReadKey();








            //Una central de distribución de químicos
            CentralDistribucion central = new CentralDistribucion();

            Console.WriteLine("=== CENTRAL DE DISTRIBUCIÓN DE ALCOHOL ===");
            Console.WriteLine("Reglas: sacas entre 3000 y 9000 L. Capacidad camión 18000-28000 L.");
            Console.WriteLine("Se cargan hasta 20 camiones diarios.\n");

            // Iniciar primer camión
            while (central.TieneCupo && central.CamionActual == null)
            {
                Console.Write("Ingrese la capacidad (L) del primer camión (18000-28000): ");
                if (int.TryParse(Console.ReadLine(), out int cap) && cap >= 18000 && cap <= 28000)
                {
                    central.IniciarNuevoCamion(cap);
                }
                else Console.WriteLine("Entrada inválida. Intente de nuevo.");
            }

            while (central.TieneCupo)
            {
                Console.Write("\nIngrese volumen de la saca (L) o 'fin' para terminar: ");
                string linea = Console.ReadLine().Trim().ToLower();
                if (linea == "fin") break;

                if (!int.TryParse(linea, out int volumen) || volumen < 3000 || volumen > 9000)
                {
                    Console.WriteLine("Volumen inválido. Debe ser número entre 3000 y 9000.");
                    continue;
                }

                var resultado = central.ProcesarSaca(volumen);
                Console.WriteLine(resultado);

                // Si el resultado indica que se despachó y hay que iniciar nuevo camión para intentar la misma saca:
                if (resultado.Contains("Inicie el siguiente camión"))
                {
                    if (!central.TieneCupo)
                    {
                        Console.WriteLine("No hay cupo para otro camión. La saca no fue procesada.");
                        break;
                    }

                    // pedir al operario la capacidad del nuevo camión y reintentar la saca
                    while (true)
                    {
                        Console.Write("Ingrese la capacidad (L) del nuevo camión (18000-28000): ");
                        if (int.TryParse(Console.ReadLine(), out int nuevaCap) && nuevaCap >= 18000 && nuevaCap <= 28000)
                        {
                            var intento = central.IntentarCargarEnNuevoCamion(nuevaCap, volumen);
                            Console.WriteLine(intento);
                            break;
                        }
                        else Console.WriteLine("Entrada inválida. Intente de nuevo.");
                    }
                }

                // si se alcanzaron 20 camiones, salir
                if (!central.TieneCupo)
                {
                    Console.WriteLine("\nSe alcanzó el máximo de 20 camiones diarios.");
                    break;
                }
            }

            // Finalizar turno: despachar parcial si existe
            central.DespacharParcialSiHay();

            Console.WriteLine("\n=== RESUMEN DEL DÍA ===");
            Console.WriteLine(central.Resumen());

            Console.WriteLine("Fin. Presione una tecla para salir.");
            Console.ReadKey();
        }
    }
}

    