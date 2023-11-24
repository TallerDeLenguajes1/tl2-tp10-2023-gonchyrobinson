using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_gonchyrobinson.Models;
namespace tl2_tp10_2023_gonchyrobinson.ViewModel;

public class ElementoTableroEnTareaViewModel{
    private int id;
    private string nombre;

    public ElementoTableroEnTareaViewModel()
    {
    }
    public ElementoTableroEnTareaViewModel(Tablero t)
    {
        id =t.Id;
        nombre=t.Nombre;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}
