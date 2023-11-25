using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class EditarTableroViewModel{

    private int id;

    private string nombre;

    private int idUsuarioAsignado;

    private List<ElementoUsuarioEditarTableroViewModel> usuarios;
    
    private string descripcion;

    public EditarTableroViewModel()
    {
    }
    public EditarTableroViewModel(Tablero t,List<Usuario> usuarios)
    {
        id=t.Id;
        nombre=t.Nombre;
        this.usuarios=new List<ElementoUsuarioEditarTableroViewModel>();
        foreach (var item in usuarios)
        {
            this.usuarios.Add(new ElementoUsuarioEditarTableroViewModel(item));
        }
        descripcion=t.Descripcion;
    }

    public int Id { get => id; set => id = value; }
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name ="Nombre del Tablero")]
    public string Nombre { get => nombre; set => nombre = value; }

    public List<ElementoUsuarioEditarTableroViewModel> Usuarios { get => usuarios; set => usuarios = value; }
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name ="Descripcion del Tablero")]
    public string Descripcion { get => descripcion; set => descripcion = value; }
    
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name ="Id del Usuario")]
    public int IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
}
