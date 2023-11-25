using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class CrearUsuarioViewModel{
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Nombre de Usuario")]
    public string NombreUs{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Contraseña del Usuario")]

    public string Contrasenia{get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Rol de Usuario")]

    public Roles Rol{get;set;}

    public CrearUsuarioViewModel()
    {
    }
    public CrearUsuarioViewModel(Usuario us){
        NombreUs=us.Nombre_de_Usuario;
        Contrasenia=us.Contrasenia;
        Rol = us.Rol;
    }
}
