using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class ElementoIndexTableroViewModel
{
    [Required][Display(Name = "Id Tablero")]
    private int id;
    [Required][Display(Name = "Id Usuario Asignado")]
    private int id_usuario_propietario;
    [Required][Display(Name = "Nombre Usuario Asignado")]
    private string nombreUsuario;
    [Required][Display(Name = "Nombre Tablero")]
    private string nombreTablero;
    [Required][Display(Name = "Descripcion Tablero")]
    private string? descripcion;

    public ElementoIndexTableroViewModel()
    {
    }
    public ElementoIndexTableroViewModel(Tablero t, List<Usuario> usuarios)
    {
        id = t.Id;
        id_usuario_propietario = t.Id_usuario_propietario;
        var usuario = usuarios.FirstOrDefault(u => u.Id == t.Id_usuario_propietario, null);
        if (usuario != null)
        {
            nombreUsuario = usuario.Nombre_de_Usuario;
        }
        else
        {
            nombreUsuario = "";
        }
        nombreTablero = t.Nombre;
        descripcion = t.Descripcion;
    }

    public int Id { get => id; set => id = value; }
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    public string NombreTablero { get => nombreTablero; set => nombreTablero = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}