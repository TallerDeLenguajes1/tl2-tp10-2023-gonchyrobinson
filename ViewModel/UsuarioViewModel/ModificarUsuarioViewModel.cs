namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
using tl2_tp10_2023_gonchyrobinson.Models;
using System.ComponentModel.DataAnnotations;


public class ModificarUsuarioViewModel{

    public int Id {get;set;}
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name = "Nombre de Usuario")]

    public string NombreUs{get;set;}
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name = "Rol de Usuario")]

    public Roles Rol{get;set;}
    [Required(ErrorMessage = "Este campo es requerido")][Display(Name = "Contraseña del Usuario")]

    public string Contrasenia{get;set;}

    public ModificarUsuarioViewModel()
    {
    }
    public ModificarUsuarioViewModel(Usuario us)
    {
        Id=us.Id;
        NombreUs=us.Nombre_de_Usuario;
        Rol=us.Rol;
        Contrasenia=us.Contrasenia;
    }

}