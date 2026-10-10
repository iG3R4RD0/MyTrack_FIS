using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AppNueva.PostgreConect
{
    internal class Conexion
    {
        private static readonly string connectionString =
            "Host=db.gjnmscqzofrafoeuwkta.supabase.co;" +
            "Port=5432;" +
            "Database=postgres;" +
            "Username=postgres;" +
            "Password=Willy Quiñonez;" +
            "SSL Mode=Require;" +
            "Trust Server Certificate=true";

        public static NpgsqlConnection GetConnection()
        {
            try
            {
                var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
     
}