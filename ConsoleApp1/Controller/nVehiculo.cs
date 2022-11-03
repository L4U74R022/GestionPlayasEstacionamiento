using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;
namespace TP2.Controller
{
    class nVehiculo
    {

      
        public static Vehiculo Crear()
        {
            Console.Clear();
            Console.Write("Ingrese Marca del Vehiculo: ");
            String Marca = utils.ingresarString();

            Console.Write("Ingrese Modelo del Vehiculo: ");
            String Modelo = utils.ingresarString();

            Console.Write("Ingrese Patente del vehiculo: ");
            String Patente = utils.ingresarString();
            //!!FALTA VALIDAR SI LA PATENTE NO EXISTE YA PREVIAMENTE 


            Vehiculo v = new Vehiculo(Marca, Modelo, Patente);
            //SUSTITUIR LA LISTA POR EL INSERT A LA BD
            Program.vehiculos.Add(v);
            return v;
        }
        public static int Seleccionar()
        {
            List<String> ops = new List<String>();
            foreach (Vehiculo v in Program.vehiculos)
            {
                String a = $"{v.Marca} - {v.Modelo} - {v.Patente} ";
                ops.Add(a);
            }

            // Validar
            Console.Write("Seleccione un vehiculo: ");
            int n = utils.CreateMenu("", ops.ToArray());
            return n;
        }

        public static void Eliminar()
        {
            Program.vehiculos.RemoveAt(Seleccionar());
        }

    }
}
