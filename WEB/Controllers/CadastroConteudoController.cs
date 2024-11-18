using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Shared;
using WEB.Models.Curso;
using WEB.Models.Turma;

namespace WEB.Controllers {
    public class CadastroConteudoController(IConfiguration configuration) : Controller {

        public async Task<IActionResult> Index(bool icAdicionar = false) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));

            ViewBag.IcAdicionar = icAdicionar;

            var ListarTurmaViewModel = new ListarTurmaViewModel() {
                IcFinalizado = false
            };
            await ListarTurmaViewModel.GerarLista(configuration);
            ViewBag.ListaTurma = ListarTurmaViewModel.ItensLista;

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