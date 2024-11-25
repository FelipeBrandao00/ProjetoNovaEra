using Microsoft.AspNetCore.Mvc;
using WEB.Models.Inscricao;
using WEB.Models.Genero;
using WEB.Models.Curso;
using WEB.Models.Turma;
using WEB.Models.Shared;
using WEB.Models.Response;


namespace WEB.Controllers {
    public class InscricaoController(IConfiguration configuration) : Controller {
        public async Task<IActionResult> Index() {

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            var listarTurmaViewModel = new ListarTurmaViewModel();
            var ListaTurmas = await listarTurmaViewModel.GerarListaMatriculasDisponiveis(configuration);
            ViewBag.ListaTurmas = listarTurmaViewModel.ItensLista;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarInscricao(ResponseModelInscricao model) {
            var response = await new InscricaoViewModel().Adicionar(configuration, model);
            return Json(response);
        }
    }
}
