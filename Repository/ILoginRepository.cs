namespace tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.Models;

public interface ILoginRepository{
    public Usuario? CoincideUs(string nombreUs, string contrasenia);
}