using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
