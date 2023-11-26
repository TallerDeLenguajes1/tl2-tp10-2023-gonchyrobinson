using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;
public class IndexTareaViewModel{
    private List<ElementoIndexTareaViewModel> tareas;
    private List<Usuario> usuarios;

    public IndexTareaViewModel()
    {
    }
    public IndexTareaViewModel(List<Tarea> t,List<Usuario> u)
    {
        this.usuarios=u;
        this.tareas=new List<ElementoIndexTareaViewModel>();
        foreach (var item in t)
        {
            tareas.Add(new ElementoIndexTareaViewModel(item,usuarios));
        }

    }

    public List<ElementoIndexTareaViewModel> Tareas { get => tareas; set => tareas = value; }
    public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
}
