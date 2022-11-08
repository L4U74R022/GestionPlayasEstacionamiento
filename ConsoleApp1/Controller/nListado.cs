using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;
using TP2.Controller;
using System.Linq;
using System.IO;

namespace TP2.Controller
{
    class nListado
    {
        public static void Menu()
        {

            string[] ops = { "1. Listar por recaudacion", "2. Listar por lugares libres", "3. Volver", "4. Guardar datos en un archivo" };

            Console.Clear();
            int opcion = utils.CreateMenu("una opcion", ops);
            Console.Clear();

            switch (opcion)
            {
                case 0: ShowCollections(); Menu(); break;
                case 1: ShowFreePlaces(); Menu(); break;
                case 2: return; 
                case 3: SaveData(); Menu(); break;
                default: Menu(); break;
            }
        }
        //Lista de mayor a menor las playas por recaudacion
        public static void ShowCollections()
        {
            List<Playa> playas = Program.playas;
            Console.Clear();
            Console.WriteLine("Cobros de las playas:");
            playas.Sort((x, y) => y.cobros.Sum().CompareTo(x.cobros.Sum()));

            foreach (Playa p in Program.playas)
            {
                Console.WriteLine($"Playa: {p.nombre} - Recaudación: ${nPlaya.CalcularCobros(p.cobros)}");
            }
            Console.ReadLine();
        }

        //Lista de mayor a menor por cantidad de lugares libres
        public static void ShowFreePlaces()
        {
            List<Playa> playas = Program.playas;
            Console.Clear();
            Console.WriteLine("Lugares libres de las playas: \n");
            playas.Sort((x, y) => y.lugaresLibres.CompareTo(x.lugaresLibres));
            int lenmax = 0;
            foreach (Playa p in Program.playas)
                if (p.nombre.Length > lenmax) lenmax = p.nombre.Length;

            foreach (Playa p in Program.playas) 
            {
                string spaces = "";
                for (int i = 0; i < lenmax - p.nombre.Length; i++) spaces += " ";
                p.nombre += spaces;
                Console.WriteLine($"Playa: {p.nombre} - Lugares libres: {p.lugaresLibres}");
            }
            Console.WriteLine("\nPresione [Enter] para continuar");
            Console.ReadLine();
        }
        
        //Guarda informes y datos en un archivo de texto
        public static void SaveData()
        {
            List<Playa> playas = Program.playas;
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Playas.txt"); ;
            using System.IO.StreamWriter sw = File.CreateText(path);
            sw.WriteLine("Datos de las playas:");
            playas.Sort((x, y) => y.lugaresLibres.CompareTo(x.lugaresLibres));
            foreach (Playa p in Program.playas)
            {
                sw.WriteLine($"Playa: {p.nombre} - Recaudación: ${nPlaya.CalcularCobros(p.cobros)} - Lugares libres: {p.lugaresLibres}");
            }

            Console.Clear();
            Console.WriteLine("¡Datos guardados correctamente!");
        }
    }
}