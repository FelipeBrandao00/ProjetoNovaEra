using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Login;

namespace WEB.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public void LoginForm(LoginViewModel loginViewModel)
    {
        var x = 1;
    }
}