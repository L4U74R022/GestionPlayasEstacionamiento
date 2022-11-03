using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Entities
{
    class Vehiculo
    {
        public Vehiculo(String Marca, String Modelo, String Patente)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Patente = Patente;
        }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Patente { get; set; }
    }
}
