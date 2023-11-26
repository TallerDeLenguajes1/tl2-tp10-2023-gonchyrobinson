using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class EditarTareaViewModel
{
    public int Id{get;set;}
    public List<ElementoTableroEnTareaViewModel> Tableros{get;set;}
    public List<ElementoUsuarioEnTareaViewModel> Usuarios{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name ="Nombre de la Tarea")]

    public string Nombre{get;set;}
    public EstadoTarea? Estado{get;set;}

    public string? Descripcion{get;set;}

    public string? Color{get;set;}

    public int? Id_usuario_asignado{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Id del Tablero asignado a la tarea")]
    public int Id_tablero{get;set;}

    public EditarTareaViewModel()
    {
    }
    public EditarTareaViewModel(Tarea t, List<Tablero> tabs, List<Usuario> us)
    {
        Id = t.Id;
        Nombre = t.Nombre;
        Tableros=new List<ElementoTableroEnTareaViewModel>();
        Usuarios=new List<ElementoUsuarioEnTareaViewModel>();
        foreach (var item in tabs)
        {
            Tableros.Add(new ElementoTableroEnTareaViewModel(item));
        }
        foreach (var item in us)
        {
            Usuarios.Add(new ElementoUsuarioEnTareaViewModel(item));
        }
        Estado=t.Estado;
        Descripcion=t.Descripcion;
        Color=t.Color;
        Id_usuario_asignado=t.Id_usuario_asignado;
        Id_tablero=t.Id_tablero;
    }

}