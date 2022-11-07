using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace TP2.Persistence
{
    class pCobro
    {
        public static void Insert(double cobro , int idplaya)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Conexion.ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Cobro (Monto, IdPlaya) values (@Monto, @Idplaya)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.Add(new SQLiteParameter("Monto", cobro ));
                cmd.Parameters.Add(new SQLiteParameter("Idplaya", idplaya));

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }

        }
    }
}
