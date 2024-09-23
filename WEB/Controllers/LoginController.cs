using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Login;

namespace WEB.Controllers;

public class LoginController(IConfiguration _configuration) : Controller
{
    public IActionResult Index()
    {
        string? token = Request.Cookies["Token"];

        if (!string.IsNullOrEmpty(token))
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginForm(LoginViewModel loginViewModel)
    {
        var result = await loginViewModel.AuthenticateAsync(_configuration);

        if (result is null) {
            ModelState.AddModelError(string.Empty, "E-mail e/ou senha inválido.");
            return View("Index");
        }

        Response.Cookies.Append("Token", result.Token);
        return RedirectToAction("Index", "Home");
    }
}