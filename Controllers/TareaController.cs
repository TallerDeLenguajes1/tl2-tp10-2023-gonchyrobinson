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

namespace tl2_tp10_2023_gonchyrobinson.Controllers;
public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;

    private TareaRepository manejo = new TareaRepository();
    private UsuarioRepository manejoUs = new UsuarioRepository();
    private TableroRepository manejoTab = new TableroRepository();
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var usuarios = manejo.Listar();
        ViewBag.Usuarios = usuarios;
        ViewBag.UsRepos = manejoUs;
        return View();
    }
    [HttpGet]
    public IActionResult Crear()
    {
        var tarea = new Tarea();
        var tableros = manejoTab.ObtenerIdDisponibles();
        var usuarios = manejoUs.ListaDeIdUsuarios();
        ViewBag.Tableros = tableros;
        ViewBag.Usuarios = usuarios;
        ViewBag.UsRepos = manejoUs;
        return View(tarea);
    }
    [HttpPost]
    public IActionResult CrearP(Tarea tar)
    {
        var tarea = manejo.CrearTarea(tar);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Editar(int id)
    {
        var tarea = manejo.ObtenerDetalles(id);
        if (tarea != null)
        {
            var tableros = manejoTab.ObtenerIdDisponibles();
            var usuarios = manejoUs.ListaDeIdUsuarios();
            ViewBag.Tableros = tableros;
            ViewBag.Usuarios = usuarios;
            ViewBag.UsRepos = manejoUs;
            return View(tarea);
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public IActionResult EditarP(Tarea t)
    {
        var tar = manejo.ModificarTarea(t.Id, t);
        return RedirectToAction("Index");
    }
    public IActionResult Eliminar(int id){
        var elimina = manejo.EliminarTarea(id);
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}