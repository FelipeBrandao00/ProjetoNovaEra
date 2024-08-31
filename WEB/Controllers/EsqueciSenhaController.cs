using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class EsqueciSenhaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfirmarCodigo()
    {
        return View();
    }
}
