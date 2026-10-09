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
        private static string connectionString = "Host=db.gjnmscqzofrafoeuwkta.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=William Quiñonez;SSL Mode=Require;Trust Server Certificate=true";

        public static NpgsqlConnection GetConnection()
        {
            try 
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
