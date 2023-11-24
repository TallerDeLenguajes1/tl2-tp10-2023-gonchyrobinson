using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class ElementoIndexTareaViewModel
{
    private int id;
    private int id_tablero;
    private string nombre;
    private EstadoTarea? estado;
    private string? descripcion;
    private string? color;
    private int? id_usuario_asignado;  
    private string? nombreUsuarioAsignado;

    public ElementoIndexTareaViewModel()
    {
    }
    public ElementoIndexTareaViewModel(Tarea t, List<Usuario> us)
    {
        id = t.Id;
        id_tablero=t.Id_tablero;
        nombre=t.Nombre;
        estado=t.Estado;
        descripcion=t.Descripcion;
        color = t.Color;
        id_usuario_asignado=t.Id_usuario_asignado;
        var usuario = us.FirstOrDefault(u => u.Id==t.Id_usuario_asignado,null);
        if (usuario!=null)
        {
            nombreUsuarioAsignado=usuario.Nombre_de_Usuario;
        }else{
            nombreUsuarioAsignado=null;
        }
    }

    public int Id { get => id; set => id = value; }
    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public EstadoTarea? Estado { get => estado; set => estado = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public int? Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
    public string? NombreUsuarioAsignado { get => nombreUsuarioAsignado; set => nombreUsuarioAsignado = value; }
}
