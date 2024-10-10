using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.CargoUsuario;
using WEB.Models.Professor;
using WEB.Models.Shared;

namespace WEB.Controllers {
    public class SistemaController(IConfiguration configuration) : Controller {
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
        public async Task<IActionResult> ListarUsuarios(ListarProfessorViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoUsuario(UsuarioViewModel UsuarioViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await UsuarioViewModel.BuscarInfo(configuration);
            return PartialView("_InfoUsuario", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarUsuario() {
            return PartialView("_AdicionarUsuario", null);
        }

        public async Task<IActionResult> AdicionarUsuario(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new UsuarioViewModel().Adicionar(configuration, ResponseModelUsuario);
            var resposeCargo = await new CargoUsuarioViewModel().AddCargoUsuario(configuration, responseAdd.Data.CdUsuario, 2);

            return PartialView("_InfoUsuario", responseAdd.Data);
        }

        [HttpPost]
        public async Task<bool> AtualizarInfoUsuario(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> AtivarUsuario(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new ProfessorViewModel().Habilitar(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> InativarUsuario(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new ProfessorViewModel().Desabilitar(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }
    }
}