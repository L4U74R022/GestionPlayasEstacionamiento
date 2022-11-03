using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;

namespace TP2.Controller
{
    class nUbicacion
    {
        public static void Menu()
        {
            if(Program.playas.Count==0)
            {
                Console.WriteLine("No existe playa para registrar el estacionamiento, por favor cree una primero. \n Presione [ENTER] para continuar");
                Console.ReadLine();
                Program.MainMenu();
            }
            Console.Clear();
            string[] opciones = { "1 - Registrar Estacionamiento", "2 - Ver estado playa", "3 - Registrar salida", "4 - Menu Principal" };
            int o = utils.CreateMenu("Ubicacion", opciones);

            switch (o)
            {
                case 0: nPlaya.AddUbicacionInPlace(); Menu(); break;
                case 1: SubMenu(); break;
                case 2: nPlaya.RegistrarSalida(); Menu(); break;
                case 3: Program.MainMenu(); break;
                default: Menu(); break;
            }
        }
        public static void Crear(int idPlaya, int fil, int col)
        {
            //Validar previamente que el lugar no esté ocupado
            Console.Clear();
            int o = utils.CreateMenu("Opcion", new String [] {" 1- Vehiculo existente ", "2 - Nuevo Vehiculo" });
            Vehiculo v;
            switch (0)
            {
                case 0:
                     v = Program.vehiculos[nVehiculo.Seleccionar()];//Reemplazar por consulta a la BD
                    break;
                case 1:
                     v = nVehiculo.Crear();
                    break;
                default:
                    break;
            }

            DateTime HoraIngreso = DateTime.Now;

            Ubicacion u = new Ubicacion(v, HoraIngreso);
            //Sustituir lista por insert 
            Program.playas[idPlaya].playa[fil, col] = u;
        }
        
        static void SubMenu()
        {
            Console.Clear();
            string[] opciones = { "1 - Grafico", "2 - Detalles" };
            int op = utils.CreateMenu("Estado Playas", opciones);
            switch (op)
            {
                case 0: EstadoDePlaya(); Menu(); break;
                case 1: DatosPlaya(); Menu(); break;
            }
        }
        public static void DatosPlaya()
        {
            Console.Clear();
            int id = nPlaya.Seleccionar();
            Ubicacion[,] lugares = Program.playas[id].playa;
            Console.WriteLine("Lugares disponibles: " + Program.playas[id].lugaresLibres);

            Console.WriteLine($"Total recaudaciones actuales:{nPlaya.CalcularCobros(Program.playas[id].cobros)}");
            for (int i = 0; i < lugares.GetLength(0); i++)
            {
                for (int j = 0; j < lugares.GetLength(1); j++)
                {
                    Ubicacion u = lugares[i, j];
                    if (u != null)
                        Console.WriteLine($" Ubicacion:{i + 1}x{j + 1} - Vehiculo: {u.VehiculoEstacionado.Marca} {u.VehiculoEstacionado.Modelo} - Patente: {u.VehiculoEstacionado.Patente} - Hora de ingreso: {u.HoraIngreso}");
                }
            }
            Console.WriteLine("Presione [Enter] para salir");
            Console.ReadLine();
        }
        public static void EstadoDePlaya()
        {
            //Gráfico de la playa de estacionamiento
            int id = nPlaya.Seleccionar();
            Playa Playa = Program.playas[id];
            Ubicacion[,] lugares = Playa.playa;

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
