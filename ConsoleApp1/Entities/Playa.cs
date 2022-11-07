using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Entities
{
    class Playa
    {
        public int idPlaya { set; get; }
        public string nombre { set; get; }
        public int cantAutosMax { set; get; }
        public int filas { set; get; }
        public int columnas { set; get; }
        public float precio_h { set; get; }
        public Ubicacion[,] playa { set; get; }
        public int lugaresLibres { set; get; }
        public List<double> cobros { get; set; }
        public Playa() 
        {
            playa = new Ubicacion[1, 1];
        }
        public Playa(int fil, int col)
        {
            playa = new Ubicacion[fil, col];
        }

        public Playa(int idPlaya , string nombre, int filas, int columnas, float precio_h)
        {
            this.idPlaya = idPlaya;
            this.nombre = nombre;
            this.cantAutosMax = filas * columnas;
            this.filas = filas;
            this.columnas = columnas;
            this.precio_h = precio_h;
            playa = new Ubicacion[filas, columnas];
            this.lugaresLibres = cantAutosMax;
            this.cobros = new List<double>();
        }

    }
}
