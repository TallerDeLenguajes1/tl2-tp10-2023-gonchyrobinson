using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class ElementoUsuarioEditarTableroViewModel{
    private int id;
    private string nombre;

    public ElementoUsuarioEditarTableroViewModel()
    {
    }
    public ElementoUsuarioEditarTableroViewModel(Usuario us)
    {
        id=us.Id;
        nombre=us.Nombre_de_Usuario;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}
