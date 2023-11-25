using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class CrearTareaViewModel{

    private int id_tablero;

    private int id_usuario_asignado;
    private List<ElementoTableroEnTareaViewModel> tableros;

    private string nombre;

    private EstadoTarea estado;

    private string? descripcion;

    private string? color;
    private List<ElementoUsuarioEnTareaViewModel> usuarios;

    public CrearTareaViewModel()
    {
    }
    public CrearTareaViewModel(List<Tablero> ts, List<Usuario>us){
        tableros=new List<ElementoTableroEnTareaViewModel>();
        usuarios=new List<ElementoUsuarioEnTareaViewModel>();
        foreach (var item in ts)
        {
            tableros.Add(new ElementoTableroEnTareaViewModel(item));
        }
        foreach (var item in us)
        {
            usuarios.Add(new ElementoUsuarioEnTareaViewModel(item));
        }
    }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Id del Tablero")]

    public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    public List<ElementoTableroEnTareaViewModel> Tableros { get => tableros; set => tableros = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Nombre del Tablero")]

    public string Nombre { get => nombre; set => nombre = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Estado del Tablero")]

    public EstadoTarea Estado { get => estado; set => estado = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public List<ElementoUsuarioEnTareaViewModel> Usuarios { get => usuarios; set => usuarios = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Id del Usuario")]

    public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
}
