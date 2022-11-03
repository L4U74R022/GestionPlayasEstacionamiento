using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TP2.Controller
{
    class utils
    {
        public static int CreateMenu(string titulo, string[] Opciones)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            int contador = 0;
            ConsoleKeyInfo Tecla;
            Console.CursorVisible = false;

            Console.WriteLine($"Seleccione {titulo}: \n");
            string resultado = Menu(Opciones, contador);

            while ((Tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                switch (Tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (contador == Opciones.Length - 1) continue;
                        Console.Clear();
                        contador++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (contador == 0) continue;
                        Console.Clear();
                        contador--;
                        break;
                }
                Console.CursorLeft = x;
                Console.CursorLeft = y;
                Console.WriteLine($"Seleccione {titulo}: \n");
                resultado = Menu(Opciones, contador);

            }

            return contador;
        }
        private static string Menu(String[] opciones, int opcion)
        {
            string Actual = string.Empty;
            int Selected = 0;

            foreach (String op in opciones)
            {
                if (Selected == opcion)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($" > {op} <");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Actual = op;
                }
                else
                {
                    Console.Write(new String(' ', Console.WindowWidth));
                    Console.CursorLeft = 0;
                    Console.WriteLine(op);
                }
                Selected++;
            }
            return Actual;
        }
        public static int ingresarInt()
        {
            int n = 0;
            T: try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("ERROR! Vuelva a ingresar un valor valido");
                goto T;
            }
            return n;
        }
        public static float ingresarFloat()
        {
            float n = 0;
            T: try
            {
                n = float.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("ERROR! Vuelva a ingresar un valor valido");
                goto T;
            }
            return n;
        }
        public static string ingresarString()
        {
            string s = "";
            T: try
            {
                while(true)
                {
                    s = Console.ReadLine();
                    if (s == "")
                        Console.WriteLine("ERROR! Complete el campo. No lo deje vacio.");
                    else break;
                } 
            }
            catch
            {
                Console.WriteLine("ERROR! Vuelva a ingresar un valor valido");
                goto T;
            }
            return s;
        }
        public static int ingresarIndice(int max)
        {
            int i = 0;
            do {
                if (i > max || i < 0) Console.WriteLine("ERROR! El dato ingresado es mayor al permitido. Vuelva a ingresarlo\n");
                i = ingresarInt() - 1;
            } while (i > max || i < 0);

            return i;
        }
    }
}