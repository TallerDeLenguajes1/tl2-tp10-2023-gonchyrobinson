using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using tl2_tp10_2023_gonchyrobinson.Models;
using tl2_tp10_2023_gonchyrobinson.Repository;
using tl2_tp10_2023_gonchyrobinson.ViewModel;

namespace tl2_tp10_2023_gonchyrobinson.Controllers;
public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly ILoginRepository _manejo;

    public LoginController(ILogger<LoginController> logger, ILoginRepository manejo)
    {
        _manejo=manejo;
        
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View(new LoginViewModel());
    }
    [HttpPost]
    public IActionResult Loguear(LoginViewModel log){
        var us = _manejo.CoincideUs(log.NombreUs,log.ContraseniaUs);
        if(us!=null){
            CrearSessionLogin(us);
            return RedirectToRoute(new{Controller="Usuario", action="Index"});
        }else
        {
            return RedirectToAction("Index");
        }
    }
    private void CrearSessionLogin(Usuario us){
        HttpContext.Session.SetString("Usuario",us.Nombre_de_Usuario);
        HttpContext.Session.SetString("Contrasenia",us.Contrasenia);
        HttpContext.Session.SetString("Rol",us.Rol.ToString());
        HttpContext.Session.SetInt32("Id",us.Id);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}