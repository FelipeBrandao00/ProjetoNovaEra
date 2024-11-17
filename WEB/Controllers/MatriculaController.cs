using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Response;
using WEB.Models.Turma;
using WEB.Models.Matricula;
using WEB.Models.Usuario;
using WEB.Models.Aluno;
using WEB.Models.Genero;
using Application.Responses;
using WEB.Models.Professor;

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

            var ListaMatriculasAtende = ListaMatriculas.Data.Where(x => x.icAtendeFiltro == true); 
            ViewBag.ListaMatriculas = ListaMatriculasAtende;
            ViewBag.QuantidadeAprovados = ListaMatriculasAtende.Count();
            return View("_ListaAlunos");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAluno(MatriculaViewModel MatriculaViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var InfoMatricula = await MatriculaViewModel.GetById(configuration, MatriculaViewModel.cdMatricula);

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            return PartialView("_InfoAluno", InfoMatricula.Data);
        }

        [HttpPost]
        public async Task<JsonResult> ConfirmarMatriculas([FromBody] int[] idMatriculas) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var retornoConfirma = await new MatriculaViewModel().EfetivarMatriculas(configuration, idMatriculas);

            return Json(retornoConfirma);
        }
    }
}