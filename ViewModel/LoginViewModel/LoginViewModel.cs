using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class LoginViewModel
{
    private string nombreUs;
    private string contraseniaUs;

    private Roles rol;
    private int idUs;
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name = "Nombre de Usuario")]
    public string NombreUs { get => nombreUs; set => nombreUs = value; }
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name = "Contraseña")]
    public string ContraseniaUs { get => contraseniaUs; set => contraseniaUs = value; }
    public Roles Rol { get => rol; set => rol = value; }
    public int IdUs { get => idUs; set => idUs = value; }

    public LoginViewModel()
    {
    }

    public LoginViewModel(Usuario us)
    {
        this.nombreUs = us.Nombre_de_Usuario;
        this.contraseniaUs = us.Contrasenia;
        this.rol=us.Rol;
        this.idUs=us.Id;
    }
}