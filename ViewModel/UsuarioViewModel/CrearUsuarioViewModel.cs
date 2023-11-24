using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class CrearUsuarioViewModel{
    [Required][Display(Name = "Nombre de Usuario")]
    private string nombreUs;
    [Required][Display(Name = "Contraseña del Usuario")]

    private string contrasenia;
    [Required][Display(Name = "Rol de Usuario")]

    private Roles rol;

    public CrearUsuarioViewModel()
    {
    }
    public CrearUsuarioViewModel(Usuario us){
        nombreUs=us.Nombre_de_Usuario;
        contrasenia=us.Contrasenia;
        rol = us.Rol;
    }

    public string NombreUs { get => nombreUs; set => nombreUs = value; }
    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    public Roles Rol { get => rol; set => rol = value; }
}
