using System;
namespace tl2_tp10_2023_gonchyrobinson.Models;
public enum Roles
{
    administrador=1,
    operador=2
}

public class Usuario

{
    private int id;
    private string nombre_de_Usuario;
    private string contrasenia;
    private Roles rol;

    public Usuario()
    {
    }

    public Usuario(string nombre_de_Usuario)
    {
        this.nombre_de_Usuario = nombre_de_Usuario;
    }

    public Usuario(string nombre_de_Usuario, string contrasenia, Roles rol)
    {
        this.id=0;
        this.nombre_de_Usuario = nombre_de_Usuario;
        this.contrasenia = contrasenia;
        this.rol = rol;
    }

    public Usuario(int id, string nombre_de_Usuario, string contrasenia, Roles rol)
    {
        this.id = id;
        this.nombre_de_Usuario = nombre_de_Usuario;
        this.contrasenia = contrasenia;
        this.rol = rol;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre_de_Usuario { get => nombre_de_Usuario; set => nombre_de_Usuario = value; }
    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    public Roles Rol { get => rol; set => rol = value; }
}
