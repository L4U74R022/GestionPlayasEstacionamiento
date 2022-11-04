using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;
using System.Data.SQLite;
using TP2.Persistence;

namespace TP2.Persistence
{
    class pPlaya
    {
        Conexion
        public static bool Insert (Playa playa)
        {
            using ()
                bool respuesta = true;
            string query = "insert into Playa (Nombre,ValorHora,Filas,Columnas) values (@Nombre, @ValorHora,@Filas,@Columnas)";
                SQLiteCommand cmd = new SQLiteCommand (query, )
                return respuesta;
        }
    }
}
