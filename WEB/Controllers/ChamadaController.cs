using Application.Responses;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WEB.Models;
using WEB.Models.Aluno;
using WEB.Models.Aula;
using WEB.Models.Chamada;
using WEB.Models.Response;
using WEB.Models.Shared;
using WEB.Models.Turma;

namespace WEB.Controllers {
    public class ChamadaController(IConfiguration configuration) : Controller {
        public async Task<IActionResult> Index() {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = dados.role[0];
            ViewBag.Nome = dados.role[1];

            configuration["JwtToken"] = token;
            ListarTurmaViewModel model = new ListarTurmaViewModel();
            model.IcFinalizado = false;
            await model.GerarLista(configuration);

            ViewBag.ListaTurmas = model.ItensLista;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarAulas(ResponseModelTurma ResponseModelTurma, bool? icChamada) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new AulaViewModel().BuscarPorTurma(configuration, ResponseModelTurma, icChamada);

            ViewBag.CdTurma = ResponseModelTurma.CdTurma;
            ViewBag.ListaAulas = response.Data;
            ViewBag.QuantidadeAulas = response.Data.Count;
            return View("_ListaAulas");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAula(ResponseModelAula ResponseModelAula, ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseChamada = await new ChamadaViewModel().BuscarPorAula(configuration, ResponseModelAula.cdAula);
            var responseAlunos = await new AlunoViewModel().BuscarPorTurma(configuration, ResponseModelTurma);

            var AulaViewModel = new AulaViewModel();
            AulaViewModel.CdAula = ResponseModelAula.cdAula;
            var infoAula = await AulaViewModel.BuscarInfo(configuration);

            if (infoAula.Data != null) {
                infoAula.Data.cdTurma = ResponseModelTurma.CdTurma;
            }

            ViewBag.ListaChamada = responseChamada.Data;
            ViewBag.ListaAlunos = responseAlunos.Data;
            ViewBag.InfoAula = infoAula.Data;
            return View("_InfoAula");
        }

        [HttpPost]
        public async Task<JsonResult> EfetivarChamada([FromBody] ChamadaViewModel ChamadaViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await ChamadaViewModel.EfetivarChamada(configuration));
        }
    }
}