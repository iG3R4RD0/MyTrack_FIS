using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AppNueva.PostgreConect
{
    internal class Procedimientos
    {
        public static Usuario GetUserPas(string correo)
        {
            using (NpgsqlConnection conexion = Conexion.GetConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM get_user_pas(@correo)", conexion);
                cmd.Parameters.AddWithValue("@correo", correo);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        UsuarioID = reader.GetInt32(0),
                        Password = reader.GetString(1)
                    };

                    return usuario;
                }
                else
                    return null;
            }
        }

        public static Usuario GetUserID(int id)
        {
            using (NpgsqlConnection conexion = Conexion.GetConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM sp_obtener_usuario_por_id(@id)", conexion);
                cmd.Parameters.AddWithValue("@id", id);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        UsuarioID = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Telefono = reader.GetString(2),
                        Correo = reader.GetString(3),
                        Password = string.Empty,
                        Tipo = reader.GetString(5),
                        Estatus = reader.GetBoolean(6)
                    };

                    return usuario;
                }
                else
                    return null;
            }
        }
    }
}
