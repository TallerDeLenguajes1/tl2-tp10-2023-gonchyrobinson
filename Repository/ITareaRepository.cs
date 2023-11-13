namespace tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.Models;


public interface ITareaRepository{
    public Tarea? CrearTarea(Tarea t);
    public bool ModificarTarea(int id, Tarea t);
    public Tarea ObtenerDetalles(int id);
    public List<Tarea> ListarTareasUsuario(int id_us);
    public List<Tarea> ListarTareasTablero(int id_tablero);
    public bool EliminarTarea(int id);
    public bool AsignarTareaUs(int idUs, int idTar);
    public bool ModificarPorNombre(int id, string nombre);
    public bool ModificarPorEstado(int id, EstadoTarea estado);
}
