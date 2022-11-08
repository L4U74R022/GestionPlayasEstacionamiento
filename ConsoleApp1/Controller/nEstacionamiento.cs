using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;
using TP2.Persistence;

namespace TP2.Controller
{
    class nEstacionamiento
    {
        public static void Menu()
        {
            Console.Clear();
            string[] opciones = { "1 - Registrar Estacionamiento", "2 - Ver estado playa", "3 - Registrar salida", "4 - Menu Principal" };
            int o = utils.CreateMenu("Ubicacion", opciones);

            switch (o)
            {
                case 0: nPlaya.AddUbicacionInPlace();  Menu(); break;
                case 1: SubMenu(); break;
                case 2: RegistrarSalida(); Menu(); break;
                case 3: Program.MainMenu(); break;
                default: Menu(); break;
            }
        }
        public static void Crear(int idPlaya, int fil, int col)
        {
            //Validar previamente que el lugar no esté ocupado
            Console.Clear();
            Vehiculo v = nVehiculo.Crear();
            DateTime HoraIngreso = DateTime.Now;
            Estacionamiento u = new Estacionamiento(fil, col, v, HoraIngreso);
            //Sustituir lista por insert 
            pEstacionamiento.Insert(u, idPlaya);
        }

        public static Estacionamiento Map(String Marca, String Modelo, String Patente, String Hora, int fil, int col)
        {
            Vehiculo v = new Vehiculo(Marca, Modelo, Patente);
            Estacionamiento u = new Estacionamiento(fil, col, v, DateTime.Parse(Hora));
            return u;   
        }
        public static void RegistrarSalida()//CAMBIAR SELECCION DE UBICACION CON NUMEROS POR MENU LISTADO DE LOS VEHICULOS EN LA PLAYA
        {
            Playa p = nPlaya.Seleccionar();

            int fil, col;
            while (true)
            {
                Console.WriteLine("Ingrese fila y columna para registrar la salida del vehiculo");
                Console.WriteLine($"Fila (entre 1 y {p.playa.GetLength(0)}): ");
                fil = utils.ingresarIndice(p.playa.GetLength(0));

                Console.WriteLine($"Columna (entre 1 y {p.playa.GetLength(1)}): ");
                col = utils.ingresarIndice(p.playa.GetLength(1));

                /*Si el lugar tiene un auto estacionado, salimos de bucle para ocupar el estacionamiento*/
                if (p.playa[fil, col] != null) break;
                else Console.WriteLine("ERROR! El lugar esta libre, no hay auto para sacar. Elija otro estacionamiento");
            }

            DateTime horaA = p.playa[fil, col].HoraIngreso;
            DateTime horaB = DateTime.Now;
            TimeSpan diferencia = horaB - horaA;
            double diff = Math.Round(diferencia.TotalHours, 2);
            double cobro = p.precio_h * diff;


            pCobro.Insert(cobro, p.idPlaya);
            Console.WriteLine($"La salida se ha registrado con exito. Horas totales: {diff} - Precio: {cobro}");
            Console.WriteLine("Presione [Enter] para continuar...");
            Console.ReadLine();
            pEstacionamiento.Delete(fil, col);
        }

        static void SubMenu()
        {
            Console.Clear();
            string[] opciones = { "1 - Grafico", "2 - Detalles" };
            int op = utils.CreateMenu("Estado Playas", opciones);
            switch (op)
            {
                case 0: GraficoDePlaya(); Menu(); break;
                case 1: DatosPlaya(); Menu(); break;
            }
        }
        public static void DatosPlaya()
        {
            Console.Clear();

            Playa playa = nPlaya.Seleccionar();
            Estacionamiento[,] lugares = playa.playa;
            Console.WriteLine("Lugares disponibles: " + playa.lugaresLibres);

            Console.WriteLine($"Total recaudaciones actuales: ${nPlaya.CalcularCobros(playa.cobros)}");
            for (int i = 0; i < lugares.GetLength(0); i++)
            {
                for (int j = 0; j < lugares.GetLength(1); j++)
                {
                    Estacionamiento u = lugares[i, j];
                    if (u != null)
                        Console.WriteLine($" Ubicacion:{i + 1}x{j + 1} - " +
                            $"Vehiculo: {u.VehiculoEstacionado.Marca} {u.VehiculoEstacionado.Modelo} -" +
                            $" Patente: {u.VehiculoEstacionado.Patente} - " +
                            $"Hora de ingreso: {u.HoraIngreso}");
                }
            }
            Console.WriteLine("Presione [Enter] para salir");
            Console.ReadLine();
        }
        public static void GraficoDePlaya()
        {
            //Gráfico de la playa de estacionamiento
            Playa Playa = nPlaya.Seleccionar();
            Estacionamiento[,] lugares = Playa.playa;

            for (int i = 0; i < Playa.filas; i++)
            {
                for (int j = 0; j < Playa.columnas; j++)
                {
                    if (lugares[i, j] != null)
                        Console.Write("|X");
                    else
                        Console.Write("| ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
