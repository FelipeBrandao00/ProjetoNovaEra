using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Professor;
using WEB.Models.Shared;

namespace WEB.Controllers {
    public class ProfessorController(IConfiguration configuration) : Controller {
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
        public async Task<IActionResult> ListarProfessores(ListarProfessorViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoProfessor(UsuarioViewModel UsuarioViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await UsuarioViewModel.BuscarInfo(configuration);
            return PartialView("_InfoProfessor", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarProfessor() {
            return PartialView("_InfoProfessor", null);
        }

        public async Task<IActionResult> AdicionarProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario);
            return PartialView("_InfoProfessor", response.Data);
        }

        [HttpPost]
        public async Task<bool> AtualizarInfoProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> HabilitarProfessor(ProfessorViewModel ProfessorViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await ProfessorViewModel.Desativar(configuration);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> DesabilitarProfessor(ProfessorViewModel ProfessorViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await ProfessorViewModel.Ativar(configuration);
            return response.IsSuccess;
        }
    }
}