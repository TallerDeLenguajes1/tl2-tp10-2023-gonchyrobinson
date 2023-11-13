namespace tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.Models;

public interface ITableroRepository{
    public Tablero? CrearTablero(Tablero t);
    public bool ModificarTablero(int id, Tablero t);
    public Tablero? ObtenerDetallesTablero(int id);
    public List<Tablero> Listar();
    public List<Tablero> ListarTablerosUs(int idUs);
    public bool Eliminar(int id);

}
