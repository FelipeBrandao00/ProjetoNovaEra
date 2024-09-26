using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using WEB.Models;
using WEB.Models.EsqueciSenha;
using WEB.Models.Shared;

namespace WEB.Controllers
{
    public class AlunoController(IConfiguration configuration) : Controller
    {
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

        [HttpGet]
        public async Task<IActionResult> ListarAlunos(ListarAlunoViewModel model)
        {
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }
    }
}