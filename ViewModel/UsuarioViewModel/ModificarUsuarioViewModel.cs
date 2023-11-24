namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
using tl2_tp10_2023_gonchyrobinson.Models;
using System.ComponentModel.DataAnnotations;


public class ModificarUsuarioViewModel{
    [Required][Display(Name = "Id de Usuario")]

    private int id;
    [Required][Display(Name = "Nombre de Usuario")]

    private string nombreUs;
    [Required][Display(Name = "Rol de Usuario")]

    private Roles rol;
    [Required][Display(Name = "Contraseña del Usuario")]

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
    public string NombreUs { get => nombreUs; set => nombreUs = value; }
    public Roles Rol { get => rol; set => rol = value; }
    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
}