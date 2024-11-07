using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Response;
using WEB.Models.Turma;
using WEB.Models.Matricula;
using WEB.Models.Usuario;
using WEB.Models.Aluno;
using WEB.Models.Genero;
using Application.Responses;

namespace WEB.Controllers {
    public class MatriculaController(IConfiguration configuration) : Controller {
        public async Task<IActionResult> Index() {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = dados.role[0];
            ViewBag.Nome = dados.role[1];

            var TurmaViewModel = new TurmaViewModel();
            var ListaTurmasAbertasMatricula = await TurmaViewModel.TurmasAbertasMatricula(configuration);
            ViewBag.ListaTurmasAbertasMatricula = ListaTurmasAbertasMatricula.Data;

            ViewBag.LinkInscricao = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/Inscricao";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarMatriculas(ResponseModelMatricula ResponseModelMatricula) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var MatriculaViewModel = new MatriculaViewModel();
            var ListaMatriculas = await MatriculaViewModel.BuscarPorTurma(configuration, ResponseModelMatricula);
            ViewBag.ListaMatriculas = ListaMatriculas.Data;
            return View("_ListaAlunos");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAluno(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var UsuarioViewModel = new UsuarioViewModel();
            UsuarioViewModel.DsCpf = ResponseModelUsuario.DsCpf;

            var InfoUsuario = await UsuarioViewModel.BuscarInfo(configuration);

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            return PartialView("_InfoAluno", InfoUsuario.Data);
        }
        
        [HttpGet]
        public async Task<IActionResult> CarregarMatriculaAluno() {
            return View("_MatriculaAluno");
        }

        //public async Task<IActionResult> CarregarAdicionarTurma() {
        //    return PartialView("_AdicionarTurma", null);
        //}

        //public async Task<IActionResult> AdicionarTurma(ResponseModelCurso ResponseModelCurso) {
        //    configuration["JwtToken"] = Request.Cookies["Token"];
        //    var responseAdd = await new CursoViewModel().Adicionar(configuration, ResponseModelCurso);

        //    return PartialView("_InfoTurma", responseAdd.Data);
        //}

        //[HttpPost]
        //public async Task<bool> AtualizarInfoTurma(ResponseModelCurso ResponseModelCurso) {
        //    configuration["JwtToken"] = Request.Cookies["Token"];
        //    var response = await new CursoViewModel().AtualizarInfo(configuration, ResponseModelCurso);
        //    return response.IsSuccess;
        //}

        //[HttpPost]
        //public async Task<bool> ReativarTurma(ResponseModelCurso ResponseModelCurso) {
        //    configuration["JwtToken"] = Request.Cookies["Token"];
        //    var response = await new CursoViewModel().Reativar(configuration, ResponseModelCurso);
        //    return response.IsSuccess;
        //}

        //[HttpPost]
        //public async Task<bool> FinalizarTurma(ResponseModelCurso ResponseModelCurso) {
        //    configuration["JwtToken"] = Request.Cookies["Token"];
        //    var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
        //    return response.IsSuccess;
        //}

        //[HttpGet]
        //public async Task<IActionResult> CarregarAulasTurma() {
        //    //configuration["JwtToken"] = Request.Cookies["Token"];
        //    //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
        //    return PartialView("_ListaAulas");
        //}

        //[HttpGet]
        //public async Task<IActionResult> CarregarAlunosTurma() {
        //    //configuration["JwtToken"] = Request.Cookies["Token"];
        //    //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
        //    return PartialView("_ListaAlunos");
        //}

        //[HttpGet]
        //public async Task<IActionResult> CarregarInfoAula() {
        //    //configuration["JwtToken"] = Request.Cookies["Token"];
        //    //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
        //    return PartialView("_InfoAula");
        //}

        //[HttpGet]
        //public async Task<IActionResult> AdicionarAula() {
        //    //configuration["JwtToken"] = Request.Cookies["Token"];
        //    //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
        //    return PartialView("_AdicionarAula");
        //}

        //[HttpGet]
        //public async Task<IActionResult> CarregarInfoAluno() {
        //    //configuration["JwtToken"] = Request.Cookies["Token"];
        //    //var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
        //    return PartialView("_InfoAluno");
        //}
    }
}