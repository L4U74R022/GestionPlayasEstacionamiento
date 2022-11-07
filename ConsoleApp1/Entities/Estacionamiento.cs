using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Entities
{
    class Estacionamiento
    {
        public Vehiculo VehiculoEstacionado { get; set; }
        public DateTime HoraIngreso { get; set; }
        public Estacionamiento(Vehiculo VehiculoEstacionado, DateTime HoraIngreso)
        {
            this.VehiculoEstacionado = VehiculoEstacionado;

            this.HoraIngreso = HoraIngreso;
        }

        public Estacionamiento()
        {
        }
    }
}
