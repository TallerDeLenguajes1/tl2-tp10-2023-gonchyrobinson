
using System.Data.SQLite;


namespace tl2_tp10_2023_gonchyrobinson.Repository;

using System.Runtime.CompilerServices;
using tl2_tp10_2023_gonchyrobinson.Models;



public class TableroRepository : ITableroRepository
{
    private string cadenaConexion = "Data Source=DB/Kanban.db;Cache=Shared";

    public Tablero? CrearTablero(Tablero t)
    {
        string queryString = @"INSERT INTO Tablero (id_usuario_propietario,nombre,descripcion) VALUES (@id_us_p,@nombre_us,@descripcion)";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_us_p", t.Id_usuario_propietario));
            command.Parameters.Add(new SQLiteParameter("@nombre_us", t.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", t.Descripcion));
            command.ExecuteNonQuery();
            connection.Close();
            return t;
        }
    }

    public bool Eliminar(int id)
    {
        var queryString = @"DELETE FROM Tablero WHERE id = @id_t";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_t", id));
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }


    public List<Tablero> Listar()
    {
        var queryString = @"SELECT * FROM Tablero";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var command = new SQLiteCommand(queryString, connection);
            var tableros = new List<Tablero>();
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int id_us_p = Convert.ToInt32(reader["id_usuario_propietario"]);
                    string nombre = reader["nombre"].ToString();
                    string descripcion = reader["descripcion"].ToString();
                    var tab = new Tablero(id, id_us_p, nombre, descripcion);
                    tableros.Add(tab);
                }
            }
            connection.Close();
            return tableros;
        }
    }

    public List<Tablero> ListarTablerosUs(int idUs)
    {
        var queryString = @"SELECT * FROM Tablero WHERE id = @id_Us";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_Us", idUs));
            var tableros = new List<Tablero>();
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int id_us_p = Convert.ToInt32(reader["id_usuario_propietario"]);
                    string nombre = reader["nombre"].ToString();
                    string descripcion = reader["descripcion"].ToString();
                    var tab = new Tablero(id, id_us_p, nombre, descripcion);
                    tableros.Add(tab);
                }
            }
            connection.Close();
            return tableros;
        }
    }

    public bool ModificarTablero(int id, Tablero t)
    {
        var queryString = @"UPDATE Tablero SET id_usuario_propietario=@id_u_p, nombre=@nombre, descripcion=@descripcion WHERE id=@id_t";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_u_p", t.Id_usuario_propietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", t.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", t.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@id_t", t.Id));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }

    public Tablero? ObtenerDetallesTablero(int id)
    {
        var queryString = @"SELECT * FROM Tablero WHERE id = @id_t";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_t", id));
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        int id_t = Convert.ToInt32(reader["id"]);
                        int id_us_p = Convert.ToInt32(reader["id_usuario_propietario"]);
                        string nombre = reader["nombre"].ToString();
                        string? descripcion = null;
                        if (!reader.IsDBNull(3))
                        {
                            descripcion = reader["descripcion"].ToString();
                        }
                        var tab = new Tablero(id_t, id_us_p, nombre, descripcion);
                        return tab;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            connection.Close();
        }
    }
    public List<int> ObtenerIdDisponibles()
    {
        var queryString = @"SELECT id FROM Tablero";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var command = new SQLiteCommand(queryString, connection);
            var tableros = new List<int>();
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    tableros.Add(id);
                }
            }
            connection.Close();
            return tableros;
        }
    }
}