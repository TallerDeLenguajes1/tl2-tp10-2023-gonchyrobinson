using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_gonchyrobinson.Models;
using tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.ViewModel;

namespace tl2_tp10_2023_gonchyrobinson.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    private UsuarioRepository manejoUsuario;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        manejoUsuario = new UsuarioRepository();
    }
    [HttpGet]
    public IActionResult Index()
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            var usuarios = manejoUsuario.ListarUsuarios();
            return View(new IndexUsuarioViewModel(usuarios));
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }
    [HttpGet]
    public IActionResult Crear()
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            return View(new CrearUsuarioViewModel());
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }
    [HttpPost]
    public IActionResult Crear(CrearUsuarioViewModel vs)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            if (!ModelState.IsValid) return RedirectToAction("Crear");
            var us = new Usuario(vs.NombreUs, vs.Contrasenia, vs.Rol);
            var creado = manejoUsuario.Crear(us);
            return RedirectToAction("Index");
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }
    //  El id debe aparecer en el formulario, pero no se debe mostrar, por esto, lo ponemos como <input hidden asp-for ="@Model.Id">

    [HttpGet]
    public IActionResult Modificar(int id)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            var us = manejoUsuario.ObtenerDetalles(id);
            if (us != null)
            {
                return View(new ModificarUsuarioViewModel(us));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }
    [HttpPost]
    public IActionResult ModificarP(ModificarUsuarioViewModel us)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            if (!ModelState.IsValid) return RedirectToAction("Modificar");
            var usuario = new Usuario(us.Id, us.NombreUs, us.Contrasenia, us.Rol);
            var modificado = manejoUsuario.Modificar(us.Id, usuario);
            return RedirectToAction("Index");
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }

    public IActionResult Eliminar(int id)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            var eliminado = manejoUsuario.EliminarUsuario(id);
            return RedirectToAction("Index");
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
