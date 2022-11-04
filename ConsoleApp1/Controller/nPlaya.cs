using System;
using System.Collections.Generic;
using TP2.Entities;
using TP2.Persistence;

namespace TP2.Controller
{
    //MODIFICAR METODO SELECCIONAR PARA TRABAJAR CON OBJETOS SACADOS DE LA BD, TRABAJAR CON OBJETOS TODOS LOS METODOS QUE USAN LA LISTA 
    class nPlaya
    {
        static public void Menu()
        {
            int op = 0;
            string[] opciones = { "1 - Crear una Playa", "2 - Listar Playas", "3 - Modificar una Playa", "4 - Eliminar una Playa", "5 - Menu principal" };
            do
            {
                Console.Clear();
                op = utils.CreateMenu("Playas", opciones) + 1;

                Console.Clear();
                switch (op)
                {
                    case 1:
                        Crear(); break;
                    case 2:
                        Listar();
                        Console.WriteLine("Presione [Enter] para salir");
                        Console.ReadLine(); break;
                    case 3:
                        Modificar(); break;
                    case 4:
                        Eliminar(); break;
                    case 5:
                        return;
                        break;
                    default:
                        Console.Clear(); break;
                }
            }
            while (op != 0);
        }
        static void Crear()
        {
            Console.WriteLine("Datos a ingresar: Nombre, Filas y Columnas de estacionamiento, Precio por hora\n");
            Console.Write("Nombre: ");
            string nombre = utils.ingresarString();
            Console.Write("\nFilas: ");
            int filas = utils.ingresarInt();
            Console.Write("\nColumnas: ");
            int columnas = utils.ingresarInt();
            Console.Write("\nPrecio por hora: ");
            float precio_h = utils.ingresarFloat();

            Playa p = new Playa(nombre, filas, columnas, precio_h);
            pPlaya.Insert(p);
        }
        static void Listar()
        {
            List<Playa> playas= pPlaya.Select();
            int i = 0;
            foreach (Playa p in playas)
            {
                Console.WriteLine("-------------------------------");
                i++;
                Console.WriteLine(i + " - Playa: " + p.nombre);
                Console.WriteLine($"    Tamaño: [{p.filas},{p.columnas}]");
                Console.WriteLine($"    Cantidad maxima: {p.cantAutosMax}");
                Console.WriteLine($"    Precio: ${p.precio_h}/h");
                Console.WriteLine($"    Lugares Libres: {p.lugaresLibres}");
            }
            Console.WriteLine("-------------------------------");
        }
        static void Mostrar(int id)
        {
            Playa p = Program.playas[id];
            Console.WriteLine($"Playa: {p.nombre} - [{p.filas},{p.columnas}] - ${p.precio_h}");
        }
        public static int Seleccionar()
        {
            /** 
             * Se crea un menú a partir de la lista de playas que haya registradas, 
             * para devolver el indice de una playa dentro de la lista
             */
            Console.Clear();
            List<String> ops = new List<String>();
            foreach (Playa p in Program.playas)
            {
                String a = $"Playa: {p.nombre} - Cantidad Maxima: {p.cantAutosMax} - Precio por hora: ${p.precio_h} - Lugares Libres: {p.lugaresLibres} - Disposicion: {p.filas}x{p.columnas}";
                ops.Add(a);
            }
            int n = utils.CreateMenu("una playa", ops.ToArray());
            return n;
        }
        static void Modificar()
        {
            Console.WriteLine("Modificar una playa");
            int playaId = Seleccionar();

            Console.Clear();
            Console.WriteLine("Modificando a la playa:");
            Mostrar(playaId);
            Playa p = Program.playas[playaId];

            Console.Write($"Nombre ({p.nombre}): ");
            p.nombre = utils.ingresarString();
            Console.Write($"Precio (${p.precio_h}): ");
            p.precio_h = utils.ingresarFloat();

            Program.playas[playaId] = p;
            Console.ReadLine();
        }
        static void Eliminar()
        {
            Console.WriteLine("Eliminar una playa");
            int playaId = Seleccionar();

            Console.WriteLine("Se ha eliminado la playa:");
            Mostrar(playaId);
            Program.playas.RemoveAt(playaId);

        }
        public static double CalcularCobros(List<double> cobros)
        {
            double res = 0;
            foreach (double cobro in cobros)
            {
                res += cobro;
            }
            return res;
        }
        public static void AddUbicacionInPlace()
        {
            int id = Seleccionar();
            int fil, col;
            while (true)
            {
                Console.WriteLine($"Ingrese fila para registrar ingreso de vehiculo (entre 1 y {Program.playas[id].playa.GetLength(0)}): ");
                fil = utils.ingresarIndice(Program.playas[id].playa.GetLength(0));

                Console.WriteLine($"Ingrese columna para registrar ingreso de vehiculo (entre 1 y {Program.playas[id].playa.GetLength(1)}): ");
                col = utils.ingresarIndice(Program.playas[id].playa.GetLength(1));

                /** Si el lugar ya estaba vacío, salimos de bucle para ocupar el estacionamiento */
                if (Program.playas[id].playa[fil, col] == null) break;//CAMBIAR ESTA COMPROBACION POR UNA EN LA BASE DE DATOS 
                else Console.WriteLine("ERROR! El lugar esta ocupado. Elija otro estacionamiento");
            }

            nUbicacion.Crear(id, fil, col);
            Console.WriteLine("Estacionamiento registrado con exito");
            Program.MainMenu();
        }
        public static void RegistrarSalida()//CAMBIAR SELECCION DE UBICACION CON NUMEROS POR MENU LISTADO DE LOS VEHICULOS EN LA PLAYA
        {
            int id = Seleccionar();

            int fil, col;
            while (true)
            {
                Console.WriteLine($"Ingrese fila para registrar ingreso de vehiculo (entre 1 y {Program.playas[id].playa.GetLength(0)}): ");
                fil = utils.ingresarIndice(Program.playas[id].playa.GetLength(0));

                Console.WriteLine($"Ingrese columna para registrar ingreso de vehiculo (entre 1 y {Program.playas[id].playa.GetLength(1)}): ");
                col = utils.ingresarIndice(Program.playas[id].playa.GetLength(1));

                /** Si el lugar tiene un auto estacionado, salimos de bucle para ocupar el estacionamiento */
                if (Program.playas[id].playa[fil, col] != null) break;
                else Console.WriteLine("ERROR! El lugar esta libre, no hay auto para sacar. Elija otro estacionamiento");
            }

            //Cobro
            float precio = Program.playas[id].precio_h;
            DateTime horaA = Program.playas[id].playa[fil, col].HoraIngreso;
            DateTime horaB = DateTime.Now;
            TimeSpan diferencia = horaB - horaA;
            double diff = Math.Round(diferencia.TotalHours, 2);
            double cobro = precio * diff;
            Program.playas[id].cobros.Add(cobro);
            Console.WriteLine($"La salida se ha registrado con exito. Horas totales: {diff} - Precio: {cobro}");
            Program.playas[id].playa[fil, col] = null;
            Program.playas[id].lugaresLibres++;
        }
    }
}