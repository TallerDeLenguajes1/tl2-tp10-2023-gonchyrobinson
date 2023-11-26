using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class CrearTareaViewModel{
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Id del Tablero")]

    public int Id_tablero{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Id del Usuario")]

    public int Id_usuario_asignado{get;set;}
    public List<ElementoTableroEnTareaViewModel> Tableros{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Nombre del Tablero")]

    public string Nombre{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Estado del Tablero")]

    public EstadoTarea Estado{get;set;}

    public string? Descripcion{get;set;}
    public string? Color{get;set;}
    public List<ElementoUsuarioEnTareaViewModel> Usuarios{get;set;}

    public CrearTareaViewModel()
    {
    }
    public CrearTareaViewModel(List<Tablero> ts, List<Usuario>us){
        Tableros=new List<ElementoTableroEnTareaViewModel>();
        Usuarios=new List<ElementoUsuarioEnTareaViewModel>();
        foreach (var item in ts)
        {
            Tableros.Add(new ElementoTableroEnTareaViewModel(item));
        }
        foreach (var item in us)
        {
            Usuarios.Add(new ElementoUsuarioEnTareaViewModel(item));
        }
    }
}
