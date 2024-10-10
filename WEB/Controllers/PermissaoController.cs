using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Shared;

namespace WEB.Controllers {
    public class PermissaoController(IConfiguration configuration) : Controller {
        public IActionResult Index() {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = dados.role[0];
            ViewBag.Nome = dados.role[1];
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarCargos(ListarAlunoViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoCargo(UsuarioViewModel UsuarioViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await UsuarioViewModel.BuscarInfo(configuration);

            return PartialView("_InfoPermissao", response.Data);
        }

        [HttpPost]
        public async Task<bool> AtualizarInfoCargo(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }
    }
}