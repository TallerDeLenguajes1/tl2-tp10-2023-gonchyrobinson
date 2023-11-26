using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class IndexTableroViewModel
{
    private List<ElementoIndexTableroViewModel> tableros;
    private List<Usuario> usuarios;

    public IndexTableroViewModel()
    {
    }

    public IndexTableroViewModel(List<Tablero> tableros, List<Usuario> usuarios)
    {
        this.usuarios=usuarios;
        this.tableros = new List<ElementoIndexTableroViewModel>();
        foreach (var item in tableros)
        {
            this.tableros.Add(new ElementoIndexTableroViewModel(item,usuarios));
        }
    }


    public List<ElementoIndexTableroViewModel> Tableros { get => tableros; set => tableros = value; }
    public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
}
