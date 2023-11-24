using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class LoginViewModel
{
    [Required][Display(Name = "Nombre de Usuario")]
    private string nombreUs;
    [Required][Display(Name = "Contraseña")]
    private string contraseniaUs;
    [Required][Display(Name = "Rol")]

    private Roles rol;
    [Required][Display(Name = "Id Usuario")]
    private int idUs;
    public string NombreUs { get => nombreUs; set => nombreUs = value; }
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