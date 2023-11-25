using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class EditarTableroViewModel{

    public int Id{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Nombre del Tablero")]

    public string Nombre{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Id del Usuario")]

    public int IdUsuarioAsignado{get;set;}

    public List<ElementoUsuarioEditarTableroViewModel> Usuarios{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Descripcion del Tablero")]
    
    public string Descripcion{get;set;}

    public EditarTableroViewModel()
    {
    }
    public EditarTableroViewModel(Tablero t,List<Usuario> usuarios)
    {
        Id=t.Id;
        Nombre=t.Nombre;
        this.Usuarios=new List<ElementoUsuarioEditarTableroViewModel>();
        foreach (var item in usuarios)
        {
            this.Usuarios.Add(new ElementoUsuarioEditarTableroViewModel(item));
        }
        Descripcion=t.Descripcion;
    }
}
