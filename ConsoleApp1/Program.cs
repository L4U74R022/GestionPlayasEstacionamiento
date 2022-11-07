using System;
using System.Collections.Generic;
using TP2.Entities;
using TP2.Controller;
namespace TP2
{
    class Program
    {
        
        
        static public List<Playa> playas;
        static public List<Vehiculo> vehiculos;

        static void Main(string[] args)
        {
            playas = new List<Playa>();
            vehiculos = new List<Vehiculo>();
            MainMenu();
        }
        public static void MainMenu()
        {
            while (true) {
                Console.Clear();
                String[] ops = {
                "1 - Administrar playas de estacionamiento",
                "2 - Registrar estacionamiento/salida",
                "3 - Informes",
                "4 - Listado Recaudaciones/Lugares Libres",
                "5 - Salir"
            };
                int op = utils.CreateMenu("una opcion", ops);
                switch (op)
                {
                    case 0: nPlaya.Menu(); break;
                    case 1: nEstacionamiento.Menu(); break;
                    case 2: nInformes.Menu(); break;
                    case 3: nListado.Menu(); break;
                    case 4: Environment.Exit(0); break;
                }
            }
        }
       /* static void DatosDemo()
        {
            playas.Add(new Playa("Norte", 120, 10, 12, 134.9f));
            playas.Add(new Playa("Este", 80, 10, 8, 113.5f));
            playas.Add(new Playa("Sureste", 96, 12, 8, 145.7f));
            playas.Add(new Playa("Sureste", 30, 6, 5, 98.2f));
            playas[0].playa[2, 2] = new Ubicacion(1, "Nissan", "Versa", "ADF 442", DateTime.Parse("3/10/2022 10:15"));
            playas[0].playa[1, 2] = new Ubicacion(2, "Toyota", "Corola", "GTF 833", DateTime.Parse("6/10/2022 11:12"));
            playas[0].playa[4, 6] = new Ubicacion(3, "Nissan", "Sentra", "KHA 542", DateTime.Parse("3/10/2022 13:21"));
            playas[0].playa[7, 2] = new Ubicacion(4, "Nissan", "GTR-34", "JLK 995", DateTime.Parse("3/10/2022 02:15"));
            playas[0].lugaresLibres -= 4;
            playas[1].playa[2, 2] = new Ubicacion(5, "Renault", "12", "HUK 119", DateTime.Parse("3/10/2022 04:15"));
            playas[1].playa[1, 2] = new Ubicacion(6, "Fiat", "147", "LGS 234", DateTime.Parse("3/10/2022 15:15"));
            playas[1].playa[4, 6] = new Ubicacion(7, "Chevrolet", "Corsa", "GKL 984", DateTime.Parse("3/10/2022 22:30"));
            playas[1].playa[7, 2] = new Ubicacion(8, "Volkswagen", "Saveiro", "AAD 032", DateTime.Parse("3/10/2022 10:30"));
            playas[1].lugaresLibres -= 4;
            playas[2].playa[2, 2] = new Ubicacion(9, "Alfa Romeo", "Mito", "LLK 498", DateTime.Parse("3/10/2022 11:15"));
            playas[2].playa[4, 5] = new Ubicacion(10, "Citroen", "C4", "LLS 543", DateTime.Parse("3/10/2022 12:15"));
            playas[2].playa[1, 2] = new Ubicacion(11, "Nissan", "370z", "FKL 870", DateTime.Parse("3/10/2022 11:30"));
            playas[2].playa[3, 4] = new Ubicacion(12, "Mazda", "RX7", "KKF 867", DateTime.Parse("3/10/2022 15:25"));
            playas[2].lugaresLibres -= 4;
            playas[3].playa[3, 4] = new Ubicacion(13, "Toyota", "Supra", "KSD 453", DateTime.Parse("3/10/2022 12:17"));
            playas[3].playa[2, 4] = new Ubicacion(14, "Ford", "Focus", "DDF 834", DateTime.Parse("3/10/2022 22:22"));
            playas[3].playa[5, 2] = new Ubicacion(15, "Chevrolet", "Onix", "LOU 123", DateTime.Parse("3/10/2022 06:15"));
            playas[3].playa[3, 1] = new Ubicacion(16, "Nissan", "Frontier", "GAS 041", DateTime.Parse("3/10/2022 15:15"));
            playas[3].lugaresLibres -= 4;
            playas[0].cobros.Add(321);
            playas[0].cobros.Add(6644);
            playas[1].cobros.Add(2341);
            playas[1].cobros.Add(663);
            playas[2].cobros.Add(2234);
            playas[2].cobros.Add(23);
            playas[3].cobros.Add(2212);
            playas[3].cobros.Add(5523);
        }*/
    }
}
