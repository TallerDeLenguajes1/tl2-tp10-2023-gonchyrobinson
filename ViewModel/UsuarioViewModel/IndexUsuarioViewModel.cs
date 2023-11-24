namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
using tl2_tp10_2023_gonchyrobinson.Models;
using System.ComponentModel.DataAnnotations;

public class IndexUsuarioViewModel{
    private List<ElementoIndexUsuarioViewModel> listaUsuarios;

    public List<ElementoIndexUsuarioViewModel> ListaUsuarios { get => listaUsuarios; set => listaUsuarios = value; }

    public IndexUsuarioViewModel(List<Usuario> usuarios)
    {
        this.listaUsuarios = new List<ElementoIndexUsuarioViewModel>();
        foreach (var us in usuarios)
        {
            var creado = new ElementoIndexUsuarioViewModel(us);
            listaUsuarios.Add(creado);
        }
    }

    public IndexUsuarioViewModel()
    {
        listaUsuarios=new List<ElementoIndexUsuarioViewModel>();
    }
}
