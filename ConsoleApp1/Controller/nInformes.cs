using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Controller;
using TP2.Entities;

namespace TP2.Controller
{
    class nInformes
    {
        public static void Menu()
        {
            string[] ops = {"1. Mostrar Informes" ,"2. Volver","3. Guardar datos en un archivo"};

            Console.Clear();
            int opcion = utils.CreateMenu("una de las siguientes opciones",ops);
            Console.Clear();

            switch (opcion)
            {
                case 0: DataTable(); Menu(); break;
                case 1: Program.MainMenu(); Menu(); break;
                case 2: SaveDataOfDataTable(); Menu(); break;
                default: Console.WriteLine("Opcion invalida"); break;
            }
        }
        public static void DataTable()
        {
            List<Playa> playas = Program.playas;
            Console.Clear();
            double total = 0;
            double total1 = 0;
            foreach (Playa p in Program.playas)
            {
                total += nPlaya.CalcularCobros(p.cobros);
                total1 += p.lugaresLibres;
            }
            Datos[1, 1] = total.ToString();
            Datos[2, 1] = total1.ToString();
            Informes.Informe(Datos);

            Console.WriteLine("\nPresione [Enter] para continuar");
            Console.ReadLine();
        }
        public static void SaveDataOfDataTable()
        {
            List<Playa> playas = Program.playas;
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Playas.txt");
            using StreamWriter sw = File.CreateText(path);
            sw.WriteLine("Datos de la Tabla: ");
            foreach (Playa p in Program.playas)
            {
                sw.WriteLine($"Recaudación por Playa: ${nPlaya.CalcularCobros(p.cobros)}");
                sw.WriteLine($"Playa: {p.nombre} - Lugares Libres: {p.lugaresLibres}");
            }
            Console.Clear();
            Console.WriteLine("¡Datos guardados correctamente!");
        }
        //Tabla de datos
        public static string[,] Datos =
        {
            { "Datos", " "},
            { "Recaudacion Total", " "},
            { "Total de Lugares Libres", " "}
        };
    }
}
