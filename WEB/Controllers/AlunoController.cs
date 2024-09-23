using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.EsqueciSenha;
using WEB.Models.Shared;

namespace WEB.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ILogger<AlunoController> _logger;

        public AlunoController(ILogger<AlunoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = dados.role[0];
            ViewBag.Nome = dados.role[1];
            return View();
        }

        public ActionResult ListarAlunos(ListarPadraoViewModel model)
        {
            model.TipoItem = "Aluno";
            model.PaginaAtual = 1;
            model.PaginaTotal = 15;
            return PartialView("_ListarPadrao", model);
        }
    }
}