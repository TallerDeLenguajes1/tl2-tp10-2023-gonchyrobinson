using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class EditarTableroViewModel{
    [Required][Display(Name ="Id del Tablero")]

    private int id;
    [Required][Display(Name ="Nombre del Tablero")]

    private string nombre;
    [Required][Display(Name ="Id del Usuario")]

    private int idUsuarioAsignado;

    private List<ElementoUsuarioEditarTableroViewModel> usuarios;
    [Required][Display(Name ="Descripcion del Tablero")]
    
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
    public string Nombre { get => nombre; set => nombre = value; }
    public List<ElementoUsuarioEditarTableroViewModel> Usuarios { get => usuarios; set => usuarios = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
}
