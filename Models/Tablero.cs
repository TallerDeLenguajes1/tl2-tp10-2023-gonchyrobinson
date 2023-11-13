namespace tl2_tp10_2023_gonchyrobinson.Models;

public class Tablero{
    private int id;
    private int id_usuario_propietario;
    private string nombre;
    private string? descripcion;

    public Tablero()
    {
    }

    public Tablero(int id, int id_usuario_propietario, string nombre, string? descripcion)
    {
        this.id = id;
        this.id_usuario_propietario = id_usuario_propietario;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }

    public int Id { get => id; set => id = value; }
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
}
