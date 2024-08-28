using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class EsqueciSenhaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
