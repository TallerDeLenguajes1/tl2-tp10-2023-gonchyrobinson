
namespace tl2_tp10_2023_gonchyrobinson.Repository;
using System.Linq;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using tl2_tp10_2023_gonchyrobinson.Models;

public class UsuarioRepository : IUsuarioRepository
{
    private string cadenaConexion = "Data Source=DB/Kanban.db;Cache=Shared";

    public UsuarioRepository()
    {
    }

    public Usuario? Crear(Usuario usuario)
    {
        var queryString = @"INSERT INTO Usuario (nombre_de_usuario,contrasenia,rol) VALUES (@nombre_usuario,@contrasenia,@rol)";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@nombre_usuario", usuario.Nombre_de_Usuario));
            query.Parameters.Add(new SQLiteParameter("@contrasenia", usuario.Contrasenia));
            query.Parameters.Add(new SQLiteParameter("@rol", usuario.Rol));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
            return usuario;
        }
    }
    public bool EliminarUsuario(int id)
    {
        string queryString = @"DELETE FROM Usuario WHERE id = @id_us";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_us", id.ToString()));
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }

    public List<Usuario> ListarUsuarios()
    {
        string queryString = @"SELECT * FROM Usuario";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            var usuarios = new List<Usuario>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nombre_de_Usuario = reader["nombre_de_usuario"].ToString();
                    string contrasenia = reader["contrasenia"].ToString();
                    Roles rol = (Roles)Convert.ToInt32(reader["rol"]);
                    var us = new Usuario(id, nombre_de_Usuario, contrasenia, rol);
                    usuarios.Add(us);
                }
            }
            connection.Close();
            return usuarios;
        }
    }

    public bool Modificar(int id, Usuario us)
    {
        string queryString = @"UPDATE Usuario SET nombre_de_usuario = @nombre_us, contrasenia=@contrasenia,rol=@rol WHERE id = @id_us";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@nombre_us", us.Nombre_de_Usuario));
            command.Parameters.Add(new SQLiteParameter("@id_us", id));
            command.Parameters.Add(new SQLiteParameter("@contrasenia", us.Contrasenia));
            command.Parameters.Add(new SQLiteParameter("@rol", us.Rol));
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }

    public Usuario? ObtenerDetalles(int id)
    {
        Usuario? us = null;
        string queryString = @"SELECT * FROM Usuario WHERE id = @id_us";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_us", id.ToString()));
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        string nombre_de_Usuario = reader["nombre_de_usuario"].ToString();
                        string contrasenia = reader["contrasenia"].ToString();
                        Roles rol = (Roles)Convert.ToInt32(reader["rol"]);
                        us = new Usuario(id, nombre_de_Usuario, contrasenia, rol);
                    }
                }
            }
            connection.Close(); 
        }
        return us;
    }
    public List<int> ListaDeIdUsuarios()
    {
        string queryString = @"SELECT id FROM Usuario";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            var usuarios = new List<int>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    usuarios.Add(id);
                }
            }
            connection.Close();
            return usuarios;
        }
    }
}