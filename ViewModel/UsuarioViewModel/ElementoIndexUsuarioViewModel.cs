using tl2_tp10_2023_gonchyrobinson.Models;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class ElementoIndexUsuarioViewModel{
    private int id;
    private string nombreUs;
    private Roles rol;

    public ElementoIndexUsuarioViewModel()
    {
    }

    public ElementoIndexUsuarioViewModel(Usuario us)
    {
        this.id = us.Id;
        this.nombreUs = us.Nombre_de_Usuario;
        this.rol = us.Rol;
    }

    public int Id { get => id; set => id = value; }
    public string NombreUs { get => nombreUs; set => nombreUs = value; }
    public Roles Rol { get => rol; set => rol = value; }
}