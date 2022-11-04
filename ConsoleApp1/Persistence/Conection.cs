﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TP3.Controladores
{
    public class Conexion
    {
        public static string ConnectionString = @"Data Source=.\playasDB.db;";
        public static SQLiteConnection connection;
        public static SQLiteConnection getConection()
        {
            if (connection == null)
            {
                connection = new SQLiteConnection(ConnectionString);
                Console.WriteLine("Nueva Conexion creada");
            }
            else
                Console.WriteLine("Reutilizando conexion");
            return connection;
        }
        
    }
}