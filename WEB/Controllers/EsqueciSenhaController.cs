using Microsoft.AspNetCore.Mvc;
using WEB.Models.EsqueciSenha;

namespace WEB.Controllers;

public class EsqueciSenhaController(IConfiguration configuration) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfirmarCodigo()
    {
        return View();
    }

    public IActionResult RedefinirSenha()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EsqueciSenhaForm(EsqueciSenhaViewModel esqueciSenhaViewModel)
    {
        var result = await esqueciSenhaViewModel.RedefinirSenhaRequest(configuration);

        if (result)
        {
            return View("ConfirmarCodigo",esqueciSenhaViewModel);
        }
        return View("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> ConfirmarCodigo(EsqueciSenhaViewModel esqueciSenhaViewModel)
    {
        var result = await esqueciSenhaViewModel.ValidarCodigo(configuration);

        if (result)
        {
            return View("ConfirmarCodigo",esqueciSenhaViewModel);
        }
        return View("Index");
    }
}
