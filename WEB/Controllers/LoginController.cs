
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}