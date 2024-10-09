using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.CargoUsuario;
using WEB.Models.Professor;
using WEB.Models.Shared;
using WEB.Models.Curso;

namespace WEB.Controllers {
    public class CursoCOntroller(IConfiguration configuration) : Controller {
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
        public async Task<IActionResult> ListarCursos(listarCursoViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoCurso(CursoViewModel CursoViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await CursoViewModel.BuscarInfo(configuration);
            return PartialView("_InfoCurso", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarCurso() {
            return PartialView("_AdicionarCurso", null);
        }

        public async Task<IActionResult> AdicionarCurso(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new CursoViewModel().Adicionar(configuration, ResponseModelCurso);

            return PartialView("_InfoCurso", responseAdd.Data);
        }

        [HttpPost]
        public async Task<bool> AtualizarInfoCurso(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().AtualizarInfo(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> HabilitarCurso(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().Habilitar(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> DesabilitarCurso(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().Desabilitar(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }
    }
}