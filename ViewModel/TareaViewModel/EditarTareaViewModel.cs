using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class EditarTareaViewModel
{

    private int id;
    private List<ElementoTableroEnTareaViewModel> tableros;
    private List<ElementoUsuarioEnTareaViewModel> usuarios;

    private string nombre;
    private EstadoTarea? estado;

    private string? descripcion;

    private string? color;

    private int? id_usuario_asignado;
    private int id_tablero;

    public EditarTareaViewModel()
    {
    }
    public EditarTareaViewModel(Tarea t, List<Tablero> tabs, List<Usuario> us)
    {
        id = t.Id;
        nombre = t.Nombre;
        tableros=new List<ElementoTableroEnTareaViewModel>();
        usuarios=new List<ElementoUsuarioEnTareaViewModel>();
        foreach (var item in tabs)
        {
            tableros.Add(new ElementoTableroEnTareaViewModel(item));
        }
        foreach (var item in us)
        {
            usuarios.Add(new ElementoUsuarioEnTareaViewModel(item));
        }
        estado=t.Estado;
        descripcion=t.Descripcion;
        color=t.Color;
        id_usuario_asignado=t.Id_usuario_asignado;
        id_tablero=t.Id_tablero;
    }

    public int Id { get => id; set => id = value; }
    public List<ElementoTableroEnTareaViewModel> Tableros { get => tableros; set => tableros = value; }
    public List<ElementoUsuarioEnTareaViewModel> Usuarios { get => usuarios; set => usuarios = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public int? Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Id del Tablero asignado a la tarea")]

    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Nombre de la Tarea")]

    public string Nombre { get => nombre; set => nombre = value; }
    public EstadoTarea? Estado { get => estado; set => estado = value; }
}