using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;
using System.Data.SQLite;


namespace TP2.Persistence
{
    class pPlaya
    {

        public static bool Insert(Playa playa)
        {
            bool respuesta = true;
            using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query = "insert into Playa (Nombre,ValorHora,Filas,Columnas) values (@Nombre, @ValorHora,@Filas,@Columnas)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.Add(new SQLiteParameter("Nombre", playa.nombre));
                cmd.Parameters.Add(new SQLiteParameter("ValorHora", playa.precio_h));
                cmd.Parameters.Add(new SQLiteParameter("Filas", playa.filas));
                cmd.Parameters.Add(new SQLiteParameter("Columnas", playa.columnas));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        //Agregar las ubicaciones a la lista en el select 
        public static List<Playa> Select()
        {
            List<Playa> lista = new List<Playa>();
            using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query = "select * from Playa";
                SQLiteCommand cmd = new SQLiteCommand(query,connection);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Playa()
                        {
                            idPlaya=int.Parse(dr["idPlaya"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            filas = int.Parse(dr["filas"].ToString()),
                            columnas = int.Parse(dr["columnas"].ToString()),
                            precio_h = float.Parse(dr["columnas"].ToString())
                        });
                    }
                }
                int cont = 0;
                foreach (Playa p in lista)
                {

                    string query2 = $" SELECT* FROM  Estacionamiento E JOIN Vehiculo V ON E.IdVehiculo = V.IdVehiculo WHERE IdPlaya ={ p.idPlaya} ";
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, connection);
                    
                    using (SQLiteDataReader dr = cmd2.ExecuteReader())
                    {
                        
                        while (dr.Read())
                        {
                            Ubicacion u = new Ubicacion(new Vehiculo(dr["Marca"].ToString(), dr["Modelo"].ToString(), dr["Patente"].ToString()), DateTime.Parse(dr["horaIngreso"].ToString()));
                            lista[cont].playa[int.Parse(dr["Fila"].ToString()), int.Parse(dr["Columna"].ToString())] = u;
                            lista[cont].lugaresLibres--;
                        }
                    }
                    cont++;
                }
                
                return lista;
            }
        }
    }
}


