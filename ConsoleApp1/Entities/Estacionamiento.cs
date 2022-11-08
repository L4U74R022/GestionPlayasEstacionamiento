using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Entities
{
    class Estacionamiento
    {
        public int fila { get; set; }
        public int columna { get; set; }
        public Vehiculo VehiculoEstacionado { get; set; }
        public DateTime HoraIngreso { get; set; }

        public Estacionamiento(int fila, int columna, Vehiculo vehiculoEstacionado, DateTime horaIngreso)
        {
            this.fila = fila;
            this.columna = columna;
            VehiculoEstacionado = vehiculoEstacionado;
            HoraIngreso = horaIngreso;
        }
    }
}
