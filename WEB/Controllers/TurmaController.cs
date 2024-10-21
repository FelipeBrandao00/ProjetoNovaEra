using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Shared;
using WEB.Models.Curso;

namespace WEB.Controllers {
    public class TurmaController(IConfiguration configuration) : Controller {
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
        public async Task<IActionResult> ListarTurmas(listarCursoViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoTurma(CursoViewModel CursoViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await CursoViewModel.BuscarInfo(configuration);
            return PartialView("_InfoTurma", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarTurma() {
            return PartialView("_AdicionarTurma", null);
        }

        public async Task<IActionResult> AdicionarTurma(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new CursoViewModel().Adicionar(configuration, ResponseModelCurso);

            return PartialView("_InfoTurma", responseAdd.Data);
        }

        [HttpPost]
        public async Task<bool> AtualizarInfoTurma(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().AtualizarInfo(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> ReativarTurma(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().Reativar(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> FinalizarTurma(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }

        [HttpGet]
        public async Task<IActionResult> CarregarAulasTurma() {
            //configuration["JwtToken"] = Request.Cookies["Token"];
            //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
            return PartialView("_ListaAulas");
        }
        
        [HttpGet]
        public async Task<IActionResult> CarregarAlunosTurma() {
            //configuration["JwtToken"] = Request.Cookies["Token"];
            //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
            return PartialView("_ListaAlunos");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAula() {
            //configuration["JwtToken"] = Request.Cookies["Token"];
            //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
            return PartialView("_InfoAula");
        }

        [HttpGet]
        public async Task<IActionResult> AdicionarAula() {
            //configuration["JwtToken"] = Request.Cookies["Token"];
            //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
            return PartialView("_AdicionarAula");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAluno() {
            //configuration["JwtToken"] = Request.Cookies["Token"];
            //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
            return PartialView("_InfoAluno");
        }
    }
}