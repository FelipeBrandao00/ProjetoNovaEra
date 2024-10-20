using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers {
    public class ChamadaController(IConfiguration configuration) : Controller {
        public IActionResult Index(bool icAdicionar = false) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = dados.role[0];
            ViewBag.Nome = dados.role[1];

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