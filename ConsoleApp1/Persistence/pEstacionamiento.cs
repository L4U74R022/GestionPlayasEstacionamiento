using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using TP2.Entities;

namespace TP2.Persistence
{
    class pEstacionamiento
    {
        public static void  Insert(Estacionamiento e,int row, int col, int idPlaya)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Estacionamiento (Fila, Columna,IdPlaya, HoraIngr, patente) values (@Fila,@Columna,@IdPlaya,@Hora,@patente)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.Add(new SQLiteParameter("Fila", row));
                cmd.Parameters.Add(new SQLiteParameter("Columna", col));
                cmd.Parameters.Add(new SQLiteParameter("IdPlaya", idPlaya ));
                cmd.Parameters.Add(new SQLiteParameter("Hora", e.HoraIngreso));
                cmd.Parameters.Add(new SQLiteParameter("patente", e.VehiculoEstacionado.Patente));
                
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query2 = "INSERT INTO Vehiculo (Marca, Modelo, Patente) values (@Marca,@Modelo,@Patente)";
                SQLiteCommand cmd = new SQLiteCommand(query2, connection);
                cmd.Parameters.Add(new SQLiteParameter("Marca", e.VehiculoEstacionado.Marca));
                cmd.Parameters.Add(new SQLiteParameter("Modelo", e.VehiculoEstacionado.Modelo));
                cmd.Parameters.Add(new SQLiteParameter("Patente", e.VehiculoEstacionado.Patente));

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int fil, int col)
        {
            string patente="";
            using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query2 = $"Select patente from Estacionamiento e Where e.fila = {fil} and e.columna = {col}";
                SQLiteCommand cmd = new SQLiteCommand(query2, connection);
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        patente = dr["patente"].ToString();

                    }
                }

                    cmd.CommandType = System.Data.CommandType.Text;
                
            }using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query2 = $"Delete from Estacionamiento  Where fila = {fil} and columna = {col}";
                SQLiteCommand cmd = new SQLiteCommand(query2, connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                
            }using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query2 = $"Delete from Vehiculo  Where patente = @patente";
                SQLiteCommand cmd = new SQLiteCommand(query2, connection);
                cmd.Parameters.Add(new SQLiteParameter("patente",patente ));
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                
            }
        }
    }

}
    