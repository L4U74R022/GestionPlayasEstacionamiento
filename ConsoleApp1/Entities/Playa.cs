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
        public Estacionamiento[,] playa { set; get; }
        public int lugaresLibres { set; get; }
        public List<double> cobros { get; set; }
        public Playa() 
        {
            playa = new Estacionamiento[1, 1];
        }
        public Playa(int fil, int col)
        {
            playa = new Estacionamiento[fil, col];
        }

        public Playa(int idPlaya , string nombre, int filas, int columnas, float precio_h)
        {
            this.idPlaya = idPlaya;
            this.nombre = nombre;
            cantAutosMax = filas * columnas;
            this.filas = filas;
            this.columnas = columnas;
            this.precio_h = precio_h;
            playa = new Estacionamiento[filas, columnas];
            lugaresLibres = cantAutosMax;
            cobros = new List<double>();
        }
        public Playa( string nombre, int filas, int columnas, float precio_h)
        {
            this.idPlaya = idPlaya;
            this.nombre = nombre;
            this.cantAutosMax = filas * columnas;
            this.filas = filas;
            this.columnas = columnas;
            this.precio_h = precio_h;
            playa = new Estacionamiento[filas, columnas];
            this.lugaresLibres = cantAutosMax;
            this.cobros = new List<double>();
        }
    }
}
