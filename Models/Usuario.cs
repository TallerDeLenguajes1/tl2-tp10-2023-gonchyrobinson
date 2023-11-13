using System;
namespace tl2_tp10_2023_gonchyrobinson.Models;

public class Usuario
{
    private int id;
    private string nombre_de_Usuario;

    public Usuario()
    {
    }

    public Usuario(string nombre_de_Usuario)
    {
        this.nombre_de_Usuario = nombre_de_Usuario;
    }

    public Usuario(int id, string nombre_de_Usuario)
    {
        this.id = id;
        this.nombre_de_Usuario = nombre_de_Usuario;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre_de_Usuario { get => nombre_de_Usuario; set => nombre_de_Usuario = value; }
}
