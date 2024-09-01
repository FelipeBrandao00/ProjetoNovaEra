using Microsoft.AspNetCore.Mvc;
using WEB.Models.EsqueciSenha;

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
    
    [HttpPost]
    public async void EsqueciSenhaForm(EsqueciSenhaViewModel esqueciSenhaViewModel)
    {
        var x = 1;
    }
}
