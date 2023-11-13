using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_gonchyrobinson.Models;
using tl2_tp10_2023_gonchyrobinson.Repository;

namespace tl2_tp10_2023_gonchyrobinson.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    private UsuarioRepository manejoUsuario = new UsuarioRepository();
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index(){
        var usuarios = manejoUsuario.ListarUsuarios();
        return View(usuarios);
    }
    [HttpGet]
    public IActionResult Crear(){
        return View(new Usuario());
    }
    [HttpPost]
    public IActionResult Crear(Usuario us){
        var usuario = manejoUsuario.Crear(us);
        return RedirectToAction("Index");
    }
    //  El id debe aparecer en el formulario, pero no se debe mostrar, por esto, lo ponemos como <input hidden asp-for ="@Model.Id">
    
    [HttpGet]
    public IActionResult Modificar(int id){
       var us = manejoUsuario.ObtenerDetalles(id);
       if (us!=null)
       {
            return View(us);
       }else{
            return RedirectToAction("Index");
       }
    }
    [HttpPost]
    public IActionResult ModificarP(Usuario us){
        var usuario = manejoUsuario.Modificar(us.Id,us);
        return RedirectToAction("Index");
    }
  
    public IActionResult Eliminar(int id){
        var eliminado = manejoUsuario.EliminarUsuario(id);
        return RedirectToAction("Index");
    }
   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    } 
}
