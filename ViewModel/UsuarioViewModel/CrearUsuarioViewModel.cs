using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class CrearUsuarioViewModel{
    private string nombreUs;

    private string contrasenia;

    private Roles rol;

    public CrearUsuarioViewModel()
    {
    }
    public CrearUsuarioViewModel(Usuario us){
        nombreUs=us.Nombre_de_Usuario;
        contrasenia=us.Contrasenia;
        rol = us.Rol;
    }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Nombre de Usuario")]

    public string NombreUs { get => nombreUs; set => nombreUs = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Contraseña del Usuario")]

    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Rol de Usuario")]

    public Roles Rol { get => rol; set => rol = value; }
}
