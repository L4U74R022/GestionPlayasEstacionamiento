using System;
using System.Collections.Generic;
using System.Text;
using TP2.Entities;
using System.Data.SQLite;
using TP2.Controller;


namespace TP2.Persistence
{
    class pPlaya
    {

        public static void Insert(Playa playa)
        {
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
                cmd.ExecuteNonQuery();
            }
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
                            precio_h = float.Parse(dr["columnas"].ToString()),
                            playa = new Estacionamiento[int.Parse(dr["filas"].ToString()), int.Parse(dr["columnas"].ToString())],
                            cobros = new List<double>(),
                            cantAutosMax= int.Parse(dr["filas"].ToString())* int.Parse(dr["columnas"].ToString()),
                            lugaresLibres = int.Parse(dr["filas"].ToString())* int.Parse(dr["columnas"].ToString()),

                        });
                    }
                }
                
                int cont = 0;
                foreach (Playa p in lista)
                {

                    string query2 = $" SELECT * FROM  Estacionamiento E JOIN Vehiculo V ON E.patente = V.Patente WHERE IdPlaya = {p.idPlaya} ";
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, connection);
                    
                    using (SQLiteDataReader dr = cmd2.ExecuteReader())
                    {
                        Estacionamiento u = new Estacionamiento();

                        while (dr.Read())
                        {
                            u = nEstacionamiento.Map(dr.GetString(6), dr.GetString(7), dr.GetString(8), dr.GetString(3));
                            lista[cont].playa[int.Parse(dr["Fila"].ToString()), int.Parse(dr["Columna"].ToString())] = u;
                            lista[cont].lugaresLibres--;
                        }
                    }
                    cont++;
                }
                int contador = 0;
                foreach (Playa p  in lista)
                {
                    string query3 = $"SELECT * FROM Cobro WHERE IdPlaya ={ p.idPlaya} ";
                    SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);

                    using (SQLiteDataReader dr = cmd3.ExecuteReader())
                    {
                        

                        while (dr.Read())
                        {

                            lista[contador].cobros.Add(double.Parse (dr["Monto"].ToString()));
                        }

                    }
                    contador++;
                }
                
                return lista;
            }
        }
    }
}


