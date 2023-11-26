using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class CrearTableroViewModel{
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Nombre Tablero")]

    public string Nombre{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Id de Usuario")]

    public int Id_usuario_propietario{get;set;}
    //Preguntar si hay problema que use 2 veces ElementoUsuarioEditarTableroViewModel
    
    public List<ElementoUsuarioEditarTableroViewModel> Usuarios{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Descripcion del Tablero")]
    public string Descripcion{get;set;}

    public CrearTableroViewModel()
    {
    }
    public CrearTableroViewModel(Tablero t, List<Usuario> usuarios)
    {
        Nombre= t.Nombre;
        Id_usuario_propietario=t.Id_usuario_propietario;
        this.Usuarios=new List<ElementoUsuarioEditarTableroViewModel>();
        foreach (var item in usuarios)
        {
            this.Usuarios.Add(new ElementoUsuarioEditarTableroViewModel(item));
        }
        Descripcion=t.Descripcion;
    }
    public CrearTableroViewModel(List<Usuario> usuarios)
    {
        this.Usuarios=new List<ElementoUsuarioEditarTableroViewModel>();
        foreach (var item in usuarios)
        {
            this.Usuarios.Add(new ElementoUsuarioEditarTableroViewModel(item));
        }
    }

}