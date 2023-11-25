using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class CrearTableroViewModel{

    private string nombre;

    private int id_usuario_propietario;
    //Preguntar si hay problema que use 2 veces ElementoUsuarioEditarTableroViewModel
    
    private List<ElementoUsuarioEditarTableroViewModel>? usuarios;
    private string descripcion;

    public CrearTableroViewModel()
    {
    }
    public CrearTableroViewModel(Tablero t, List<Usuario> usuarios)
    {
        nombre= t.Nombre;
        id_usuario_propietario=t.Id_usuario_propietario;
        this.usuarios=new List<ElementoUsuarioEditarTableroViewModel>();
        foreach (var item in usuarios)
        {
            this.usuarios.Add(new ElementoUsuarioEditarTableroViewModel(item));
        }
        descripcion=t.Descripcion;
    }
    public CrearTableroViewModel(List<Usuario> usuarios)
    {
        this.usuarios=new List<ElementoUsuarioEditarTableroViewModel>();
        foreach (var item in usuarios)
        {
            this.usuarios.Add(new ElementoUsuarioEditarTableroViewModel(item));
        }
    }

    [Required(ErrorMessage = "Este campo es requerido")][Display(Name = "Nombre Tablero")]
    public string Nombre { get => nombre; set => nombre = value; }
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    public List<ElementoUsuarioEditarTableroViewModel>? Usuarios { get => usuarios; set => usuarios = value; }
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name ="Descripcion del Tablero")]
    public string Descripcion { get => descripcion; set => descripcion = value; }
}