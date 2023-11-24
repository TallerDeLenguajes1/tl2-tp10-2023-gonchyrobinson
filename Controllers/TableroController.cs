using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_gonchyrobinson.Models;
using tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.ViewModel;

namespace tl2_tp10_2023_gonchyrobinson.Controllers;
public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;

    private UsuarioRepository manejoUsuario;
    private TableroRepository manejo;
    public TableroController(ILogger<TableroController> logger)
    {
        manejo = new TableroRepository();
        manejoUsuario = new UsuarioRepository();
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index(int? id)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            List<Tablero> tableros;
            var usuarios = manejoUsuario.ListarUsuarios();
            var rol = HttpContext.Session.GetString("Rol");
            if (id != null && (HttpContext.Session.GetInt32("Id") == id || rol == "administrador"))
            {
                tableros = manejo.ListarTablerosUs((int)id);
                return View(new IndexTableroViewModel(tableros, usuarios));
            }
            else
            {
                if (id == null)
                {
                    tableros = manejo.ListarTablerosUs((int)HttpContext.Session.GetInt32("Id"));
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
            var tableros = manejo.Listar();
            var usuarios = manejoUsuario.ListarUsuarios();
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
            var tablero = new Tablero(0, t.Id_usuario_propietario, t.Nombre, t.Descripcion);
            var creado = manejo.CrearTablero(tablero);
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
            var usuarios = manejoUsuario.ListarUsuarios();
            var editar = manejo.ObtenerDetallesTablero(id);
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
            var tablero = new Tablero(t.Id, t.IdUsuarioAsignado, t.Nombre, t.Descripcion);
            var editar = manejo.ModificarTablero(t.Id, tablero);
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
            var eliminado = manejo.Eliminar(id);
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