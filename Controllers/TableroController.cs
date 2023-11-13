using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_gonchyrobinson.Models;
using tl2_tp10_2023_gonchyrobinson.Repository;

namespace tl2_tp10_2023_gonchyrobinson.Controllers;
public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;

    private UsuarioRepository manejoUsuario = new UsuarioRepository();
    private TableroRepository manejo = new TableroRepository();
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var tableros = manejo.Listar();
        ViewBag.UsRepos = manejoUsuario;
        return View(tableros);
    }
    [HttpGet]
    public IActionResult Crear()
    {
        ViewBag.UsRepos = manejoUsuario;
        return View(new Tablero());
    }
    [HttpPost]
    public IActionResult CrearP(Tablero us)
    {
        var tablero = manejo.CrearTablero(us);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Editar(int id)
    {
        var editar = manejo.ObtenerDetallesTablero(id);
        if (editar != null)
        {
            ViewBag.UsRepos = manejoUsuario;
            return View(editar);
        }else
        {
            return RedirectToAction("Index");
        }
    }
    public IActionResult EditarP(Tablero t){
        var editar = manejo.ModificarTablero(t.Id,t);
        return RedirectToAction("Index");
    }
    public IActionResult Eliminar(int id){
        var eliminado = manejo.Eliminar(id);
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}