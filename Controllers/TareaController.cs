// Las de eliminar no necesitan una view
// E, metodo index suele ser el listar
// Por ende deberiamos tener un index por controlador. Es decir, uno en el usuarioController, uno en el tareaController y uno en el tableroController
//  Si yo hago esto Producto/ y no pongo nada, por defecto va al index. Por ende, en vez de crear un método de listar productos construyo un index
//  La url se arma como localhost://NombreControlador/Metodo(o VIEW)
// Ekemplo del caso de producto, crear producto, la url seria localhost:2343/Producto/CrearProducto/parametros(que van en cabecera, no en body)
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_gonchyrobinson.Models;
using tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.ViewModel;

namespace tl2_tp10_2023_gonchyrobinson.Controllers;
public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;

    private TareaRepository manejo = new TareaRepository();
    private readonly IUsuarioRepository _manejoUs;
    private readonly ITableroRepository _manejoTab;

    public TareaController(ILogger<TareaController> logger, IUsuarioRepository manejoUs, ITableroRepository manejoTab)
    {
        _logger = logger;
        _manejoUs = manejoUs;
        _manejoTab = manejoTab;
    }
    [HttpGet]
    public IActionResult Index(int? id)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            var usuarios = _manejoUs.ListarUsuarios();
            if (id != null && (HttpContext.Session.GetInt32("Id") == id || HttpContext.Session.GetString("Rol") == "administrador"))
            {
                var tareas = manejo.ListarTareasUsuario((int)id);
                return View(new IndexTareaViewModel(tareas, usuarios));
            }
            else
            {
                if (id == null)
                {
                    var tareas = manejo.ListarTareasUsuario((int)HttpContext.Session.GetInt32("Id"));
                    return View(new IndexTareaViewModel(tareas,usuarios));
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
            var tableros = _manejoTab.Listar();
            var usuarios = _manejoUs.ListarUsuarios();
            return View(new CrearTareaViewModel(tableros, usuarios));
        }
        else
        {
            return (RedirectToRoute(new { Controller = "Login", action = "Index" }));
        }

    }
    [HttpPost]
    public IActionResult CrearP(CrearTareaViewModel tar)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            if(!ModelState.IsValid) return RedirectToAction("Crear");
            var tarea = manejo.CrearTarea(new Tarea(tar.Id_tablero, tar.Nombre, tar.Estado, tar.Descripcion, tar.Color, tar.Id_usuario_asignado));
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
            var tarea = manejo.ObtenerDetalles(id);
            if (tarea != null)
            {
                var tableros = _manejoTab.Listar();
                var usuarios = _manejoUs.ListarUsuarios();
                return View(new EditarTareaViewModel(tarea, tableros, usuarios));
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
    public IActionResult EditarP(EditarTareaViewModel t)
    {
        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("Usuario") != null)
        {
            if(!ModelState.IsValid) return RedirectToAction("Editar");
            var tar = new Tarea(t.Id_tablero, t.Nombre, t.Estado, t.Descripcion, t.Color, t.Id_usuario_asignado);
            var modificado = manejo.ModificarTarea(t.Id, tar);
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
            var elimina = manejo.EliminarTarea(id);
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