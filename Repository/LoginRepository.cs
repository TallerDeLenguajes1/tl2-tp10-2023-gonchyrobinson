namespace tl2_tp10_2023_gonchyrobinson.Repository;

using System.Data.SQLite;
using tl2_tp10_2023_gonchyrobinson.Models;

public class LoginRepository : ILoginRepository
{
    private string cadenaConexion = "Data Source=DB/Kanban.db;Cache=Shared";
    public LoginRepository()
    {
    }
    //Es correcto acá crear un repositorio para el login, o se lo hace directamente en el de usuarios

    public Usuario? CoincideUs(string nombreUs, string contrasenia)
    {
        string queryString = "Select * from Usuario Where nombre_de_usuario =@nombreUs and contrasenia=@contrasenia";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var command = new SQLiteCommand(queryString,connection);
            command.Parameters.Add(new SQLiteParameter("@nombreUs",nombreUs));
            command.Parameters.Add(new SQLiteParameter("@contrasenia",contrasenia));
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var n = reader["nombre_de_usuario"].ToString();
                    var contra = reader["contrasenia"].ToString();
                    var rol = (Roles)Convert.ToInt32(reader["rol"]);
                    var id = Convert.ToInt32(reader["id"]);
                    connection.Close();
                    return new Usuario(id,n,contra,rol);
                }else
                {
                    connection.Close();
                    return null;
                }
            }
        }
    }
}