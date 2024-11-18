using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Shared;
using WEB.Models.Curso;

namespace WEB.Controllers {
    public class CadastroConteudoController(IConfiguration configuration) : Controller {

        public IActionResult Index(bool icAdicionar = false) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));

            ViewBag.IcAdicionar = icAdicionar;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarAulas() {
            return View("_ListaAulas");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAula() {
            return View("_InfoAula");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarAdicionarArquivo() {
            return View("_AdicionarArquivo");
        }

    }
}