using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string? token = Request.Cookies["Token"];
        if (string.IsNullOrEmpty(token)) {
            return RedirectToAction("Index", "Login");
        }

        var dados = JwtToken.DescriptografarJwt(token);
        ViewBag.Role = dados.role[0];
        ViewBag.Nome = dados.role[1];
        return View();
    }

    public IActionResult Sair()
    {
        Response.Cookies.Delete("Token");
        return RedirectToAction("Index", "Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}