using Microsoft.AspNetCore.Mvc;
using WEB.Models.EsqueciSenha;

namespace WEB.Controllers;

public class EsqueciSenhaController(IConfiguration configuration) : Controller
{
    public IActionResult Index(bool? icTrocar = null)
    {
        if (icTrocar == true) {
            return View();
        }

        string? token = Request.Cookies["Token"];

        if (!string.IsNullOrEmpty(token)) {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    public IActionResult ConfirmarCodigo()
    {
        string? token = Request.Cookies["Token"];

        if (!string.IsNullOrEmpty(token))
            return RedirectToAction("Index", "Home");

        return View();
    }

    public IActionResult RedefinirSenha(string email)
    {
        string? token = Request.Cookies["Token"];

        if (!string.IsNullOrEmpty(token))
            return RedirectToAction("Index", "Home");

        var model = new EsqueciSenhaViewModel { Email = email };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EsqueciSenhaForm(EsqueciSenhaViewModel esqueciSenhaViewModel)
    {
        var result = await esqueciSenhaViewModel.RedefinirSenhaRequest(configuration);

        if (result)
        {
            return View("ConfirmarCodigo", esqueciSenhaViewModel);
        }
        return View("Index");
    }
    
    [HttpPost]
    public async Task<bool> ConfirmarCodigo(EsqueciSenhaViewModel esqueciSenhaViewModel)
    {
        return await esqueciSenhaViewModel.ValidarCodigo(configuration);
    }
    
    [HttpPost]
    public async Task<bool> TrocarSenha(EsqueciSenhaViewModel esqueciSenhaViewModel)
    {
        if (esqueciSenhaViewModel.NovaSenha != esqueciSenhaViewModel.SenhaConfirmada) return false;
        return await esqueciSenhaViewModel.RedefinirSenha(configuration);
    }
}
