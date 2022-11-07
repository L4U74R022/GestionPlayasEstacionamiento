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
                case 2: nPlaya.RegistrarSalida(); Menu(); break;
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

            Estacionamiento u = new Estacionamiento(v, HoraIngreso);
            //Sustituir lista por insert 
            pEstacionamiento.Insert(u, fil, col, idPlaya);
            
        }
        public static Estacionamiento Map(String Marca, String Modelo, String Patente, String Hora)
        {
            Vehiculo v = new Vehiculo(Marca,Modelo,Patente);
            Estacionamiento u = new Estacionamiento(v, DateTime.Parse(Hora));
            return u;
           
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
            Playa playa = nPlaya.Seleccionar();
            Estacionamiento[,] lugares = playa.playa;
            Console.WriteLine("Lugares disponibles: " + playa.lugaresLibres);

            Console.WriteLine($"Total recaudaciones actuales:{nPlaya.CalcularCobros(playa.cobros)}");
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
        public static void EstadoDePlaya()
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
