using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_gonchyrobinson.Models;
using tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.ViewModel;

namespace tl2_tp10_2023_gonchyrobinson.Controllers;
public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;

    private readonly IUsuarioRepository _manejoUsuario;
    private readonly ITableroRepository _manejo;
    public TableroController(ILogger<TableroController> logger,IUsuarioRepository manejoUs, ITableroRepository manejo)
    {
        _logger = logger;
        _manejoUsuario=manejoUs;
        _manejo=manejo;
    }
    [HttpGet]
    public IActionResult Index(int? id)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            List<Tablero> tableros;
            var usuarios = _manejoUsuario.ListarUsuarios();
            var rol = HttpContext.Session.GetString("Rol");
            if (id != null && (HttpContext.Session.GetInt32("Id") == id || rol == "administrador"))
            {
                tableros = _manejo.ListarTablerosUs((int)id);
                return View(new IndexTableroViewModel(tableros, usuarios));
            }
            else
            {
                if (id == null)
                {
                    tableros = _manejo.ListarTablerosUs((int)HttpContext.Session.GetInt32("Id"));
                    return View(new IndexTableroViewModel(tableros, usuarios));
                }
            }
        }
        return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
    }
    [HttpGet]
    public IActionResult Crear()
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            var tableros = _manejo.Listar();
            var usuarios = _manejoUsuario.ListarUsuarios();
            return View(new CrearTableroViewModel(usuarios));
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }
    [HttpPost]
    public IActionResult CrearP(CrearTableroViewModel t)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            if(!ModelState.IsValid) return RedirectToAction("Crear");
            var tablero = new Tablero(0, t.Id_usuario_propietario, t.Nombre, t.Descripcion);
            var creado = _manejo.CrearTablero(tablero);
            return RedirectToAction("Index");
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }
    [HttpGet]
    public IActionResult Editar(int id)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            var usuarios = _manejoUsuario.ListarUsuarios();
            var editar = _manejo.ObtenerDetallesTablero(id);
            if (editar != null)
            {
                return View(new EditarTableroViewModel(editar, usuarios));
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
    public IActionResult EditarP(EditarTableroViewModel t)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            if(!ModelState.IsValid) return RedirectToAction("Editar");
            var tablero = new Tablero(t.Id, t.IdUsuarioAsignado, t.Nombre, t.Descripcion);
            var editar = _manejo.ModificarTablero(t.Id, tablero);
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
            var eliminado = _manejo.Eliminar(id);
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