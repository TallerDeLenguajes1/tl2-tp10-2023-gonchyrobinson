namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
using tl2_tp10_2023_gonchyrobinson.Models;
using System.ComponentModel.DataAnnotations;


public class ModificarUsuarioViewModel{

    private int id;

    private string nombreUs;

    private Roles rol;

    private string contrasenia;

    public ModificarUsuarioViewModel()
    {
    }
    public ModificarUsuarioViewModel(Usuario us)
    {
        id=us.Id;
        nombreUs=us.Nombre_de_Usuario;
        rol=us.Rol;
        contrasenia=us.Contrasenia;
    }

    public int Id { get => id; set => id = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Nombre de Usuario")]

    public string NombreUs { get => nombreUs; set => nombreUs = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Rol de Usuario")]

    public Roles Rol { get => rol; set => rol = value; }
    [Required(ErrorMessage ="Este campo es requerido")][Display(Name = "Contraseña del Usuario")]

    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
}