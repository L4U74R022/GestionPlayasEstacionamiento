using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;
using TP2.Controller;


namespace TP2.Entities
{
    class Informes
    {
        public static void Informe(string[,] t)
        {
            int th = t.GetLength(0); // Altura de la matriz
            int tw = t.GetLength(1); // Anchura de la matriz

            // Calculando tamaño máximo para cada columna
            int[] columnSizes = new int[tw];
            for (int i = 0; i < columnSizes.Length; i++) columnSizes[i] = 0;
            /* Va a guardar la longitud del dato mas largo de cada columna */
            for (int i = 0; i < th; i++)
                for (int j = 0; j < tw; j++)
                    columnSizes[j] = t[i, j].Length > columnSizes[j] ? t[i, j].Length : columnSizes[j];
            // Calculando ancho/largo total
            int largoTot = tw * 2 + (tw + 1);
            for (int i = 0; i < columnSizes.Length; i++) largoTot += columnSizes[i];

            // Borde superior
            for (int i = 0; i < largoTot; i++)
                if (i == 0)
                    Console.Write("╔");
                else
                {
                    if (i == largoTot - 1) Console.Write("╗");
                    else
                    {
                        bool intersecBorde = false;
                        for (int j = 0; j < columnSizes.Length - 1; j++)
                        {
                            int colEnd = 0;
                            for (int k = j; k >= 0; k--)
                            {
                                colEnd += columnSizes[k] + 3;
                            }
                            if (i == colEnd)
                            {
                                Console.Write("╦");
                                intersecBorde = true;
                            }
                        }
                        if (!intersecBorde) Console.Write("═");
                    }
                }
            Console.WriteLine();

            // Contenido, con bordes laterales e interiores
            for (int i = 0; i < th; i++)
            {
                if (i == 1)
                { //Bordes interior horizontales para los titulos
                    for (int j = 0; j < largoTot; j++)
                    {
                        if (j == 0) Console.Write("╠");
                        else
                            if (j == largoTot - 1) Console.Write("╣");
                        else
                        {
                            bool intersecBorde = false;
                            for (int l = 0; l < columnSizes.Length - 1; l++)
                            {
                                int colEnd = 0;
                                for (int k = l; k >= 0; k--)
                                {
                                    colEnd += columnSizes[k] + 3;
                                }
                                if (j == colEnd)
                                {
                                    Console.Write("╬");
                                    intersecBorde = true;
                                }
                            }
                            if (!intersecBorde) Console.Write("═");
                        }
                    }
                    Console.WriteLine();
                }


                Console.Write("║");
                for (int j = 0; j < tw; j++)
                {
                    Console.Write(" ");
                    if (i == 0) Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(t[i, j]);
                    if (i == 0) Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    // Relleno del espacio de cada dato dentro de la columna correspondiente
                    for (int x = 0; x < columnSizes[j] - t[i, j].Length; x++) Console.Write(" ");
                    Console.Write("║");
                }
                Console.WriteLine();
            }

            //Borde inferior
            for (int i = 0; i < largoTot; i++)
                if (i == 0)
                    Console.Write("╚");
                else
                    if (i == largoTot - 1)
                    Console.Write("╝");
                else
                {
                    bool intersecBorde = false;
                    for (int j = 0; j < columnSizes.Length - 1; j++)
                    {
                        int colEnd = 0;
                        for (int k = j; k >= 0; k--)
                        {
                            colEnd += columnSizes[k] + 3;
                        }
                        if (i == colEnd)
                        {
                            Console.Write("╩");
                            intersecBorde = true;
                        }
                    }

                    if (!intersecBorde) Console.Write("═");
                }
            Console.WriteLine();
        }
    }
}
