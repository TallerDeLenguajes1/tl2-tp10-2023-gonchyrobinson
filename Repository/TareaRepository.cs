using System.Data.SQLite;
namespace tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.Models;


public class TareaRepository : ITareaRepository
{
    private string cadenaConexion = "Data Source=DB/Kanban.db;Cache=Shared";
    public bool AsignarTareaUs(int idUs, int idTar)
    {
        var queryString = @"UPDATE Tarea SET id_usuario_asignado = @id_U  WHERE id = @id_t";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id_U", idUs));
            query.Parameters.Add(new SQLiteParameter("@id_t", idTar));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }

    public Tarea? CrearTarea(Tarea t)
    {
        string queryString = @"INSERT INTO Tarea (id_tablero,nombre,estado,descripcion,color,id_usuario_asignado) VALUES (@id_t,@nombre,@estado,@descripcion,@color,@id_usuario_asignado)";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_t", t.Id_tablero));
            command.Parameters.Add(new SQLiteParameter("@nombre", t.Nombre));
            command.Parameters.Add(new SQLiteParameter("@estado", t.Estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion", t.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color", t.Color));
            command.Parameters.Add(new SQLiteParameter("@id_usuario_asignado", t.Id_usuario_asignado));
            command.ExecuteNonQuery();
            connection.Close();
            return t;
        }
    }

    public bool EliminarTarea(int id)
    {
        var queryString = @"DELETE FROM Tarea WHERE id = @id";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }

    public List<Tarea> ListarTareasTablero(int id_tablero)
    {
        var queryString = @"SELECT * FROM Tarea WHERE id_tablero=@id_tablero";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id_tablero", id_tablero));
            connection.Open();
            using (var reader = query.ExecuteReader())
            {
                var tareas = new List<Tarea>();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int id_tab = Convert.ToInt32(reader["id_tablero"]);
                    string nombre = reader["nombre"].ToString();
                    EstadoTarea estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                    string descripcion = reader["descripcion"].ToString();
                    string color = reader["color"].ToString();
                    int? id_us;
                    if (!reader.IsDBNull(6))
                    {
                        id_us = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                    else
                    {
                        id_us = null;
                    }
                    var t = new Tarea(id, id_tab, nombre, estado, descripcion, color, id_us);
                    tareas.Add(t);
                }
                connection.Close();
                return tareas;
            }
        }
    }

    public List<Tarea> ListarTareasUsuario(int id_us)
    {
        var queryString = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @id_us";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id_us", id_us));
            connection.Open();
            using (var reader = query.ExecuteReader())
            {
                var tareas = new List<Tarea>();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int id_tab = Convert.ToInt32(reader["id_tablero"]);
                    string nombre = reader["nombre"].ToString();
                    EstadoTarea estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                    string descripcion = reader["descripcion"].ToString();
                    string color = reader["color"].ToString();
                    int? id_u;
                    if (!reader.IsDBNull(6))
                    {
                        id_u = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                    else
                    {
                        id_u = null;
                    }
                    var t = new Tarea(id, id_tab, nombre, estado, descripcion, color, id_u);
                    tareas.Add(t);
                }
                connection.Close();
                return tareas;
            }
        }
    }

    public bool ModificarTarea(int id, Tarea t)
    {
        var queryString = @"UPDATE Tarea SET id_tablero=@id_tablero,nombre=@nombre,estado=@estado,descripcion=@descripcion,color=@color,id_usuario_asignado=@id_usuario_asignado WHERE id=@id";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id_tablero", t.Id_tablero));
            query.Parameters.Add(new SQLiteParameter("@nombre", t.Nombre));
            query.Parameters.Add(new SQLiteParameter("@estado", t.Estado));
            query.Parameters.Add(new SQLiteParameter("@descripcion", t.Descripcion));
            query.Parameters.Add(new SQLiteParameter("@color", t.Color));
            query.Parameters.Add(new SQLiteParameter("@id_usuario_asignado", t.Id_usuario_asignado));
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }

    public Tarea ObtenerDetalles(int id)
    {
        var queryString = @"SELECT * FROM Tarea WHERE id=@id";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            using (var reader = query.ExecuteReader())
            {
                reader.Read();

                int idT = Convert.ToInt32(reader["id"]);
                int id_tab = Convert.ToInt32(reader["id_tablero"]);
                string nombre = reader["nombre"].ToString();
                EstadoTarea estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                string descripcion = reader["descripcion"].ToString();
                string color = reader["color"].ToString();
                int? id_us;
                if (!reader.IsDBNull(6))
                {
                    id_us = Convert.ToInt32(reader["id_usuario_asignado"]);
                }
                else
                {
                    id_us = null;
                }
                var t = new Tarea(idT, id_tab, nombre, estado, descripcion, color, id_us);
                connection.Close();
                return t;
            }
        }
    }

    public bool ModificarPorNombre(int id, string nombre)
    {
        var queryString = @"UPDATE Tarea SET nombre=@nombre WHERE id=@id";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@nombre", nombre));
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }
    public bool ModificarPorEstado(int id, EstadoTarea estado)
    {
        var queryString = @"UPDATE Tarea SET estado=@estado WHERE id=@id";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@estado", estado));
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }
    public int? ContarTareasEstado(EstadoTarea estado)
    {
        var queryString = @"SELECT COUNT(*) FROM Tarea WHERE estado=@estado";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@estado", estado));
            connection.Open();
            var cant = Convert.ToInt32(query.ExecuteScalar());
            connection.Close();
            return cant;
        }
    }
    public List<Tarea> Listar()
    {
        var queryString = @"SELECT * FROM Tarea";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var query = new SQLiteCommand(queryString, connection);
            var tareas = new List<Tarea>();
            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int id_tab = Convert.ToInt32(reader["id_tablero"]);
                    string nombre = reader["nombre"].ToString();
                    EstadoTarea estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                    string descripcion = reader["descripcion"].ToString();
                    string color = reader["color"].ToString();
                    int? id_us;
                    if (!reader.IsDBNull(6))
                    {
                        id_us = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                    else
                    {
                        id_us = null;
                    }
                    var t = new Tarea(id, id_tab, nombre, estado, descripcion, color, id_us);
                    tareas.Add(t);
                }
            }
            connection.Close();
            return tareas;
        }
    }
}