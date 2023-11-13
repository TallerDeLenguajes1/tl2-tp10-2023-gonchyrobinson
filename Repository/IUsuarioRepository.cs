

namespace tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.Models;

public interface IUsuarioRepository{
    public Usuario? Crear(Usuario usuario);
    public bool Modificar(int id, Usuario us);
    public List<Usuario> ListarUsuarios();
    public Usuario? ObtenerDetalles(int id);
    public bool EliminarUsuario(int id);
}
