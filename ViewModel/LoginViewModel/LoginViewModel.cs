using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class LoginViewModel
{
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Nombre de Usuario")]
    public string NombreUs {get;set;}
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Contraseña")]
    public string ContraseniaUs {get; set;}
    public Roles Rol {get;set;}
    public int IdUs {get;set;}

    public LoginViewModel()
    {
    }

    public LoginViewModel(Usuario us)
    {
        this.NombreUs = us.Nombre_de_Usuario;
        this.ContraseniaUs = us.Contrasenia;
        this.Rol=us.Rol;
        this.IdUs=us.Id;
    }
}