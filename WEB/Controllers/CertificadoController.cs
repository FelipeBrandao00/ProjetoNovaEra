using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Aluno;
using WEB.Models.Genero;
using WEB.Models.Shared;
using WEB.Models.Usuario;

namespace WEB.Controllers {
    public class CertificadoController(IConfiguration configuration) : Controller {
        public IActionResult Index() {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarAlunos(ListarAlunoViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAluno(UsuarioViewModel UsuarioViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var InfoUsuario = await UsuarioViewModel.BuscarInfo(configuration);

            return PartialView("_InfoCertificado", InfoUsuario.Data);
        }
    }
}