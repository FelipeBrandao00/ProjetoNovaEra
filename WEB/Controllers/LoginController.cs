
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Login;

namespace WEB.Controllers;

public class LoginController(IConfiguration configuration) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async void LoginForm(LoginViewModel loginViewModel)
    {
       var result = await loginViewModel.AuthenticateAsync(configuration);

       if (result is null)
       {
           //redirecionar para tela de login com erro
       }else
       {
           //redirecionar home e armazenar token
       }
    }
}