using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Shared;
using WEB.Models.Curso;
using WEB.Models.Professor;
using WEB.Models.Turma;
using WEB.Models.Aluno;
using WEB.Models.TurmaAluno;
using WEB.Models.Usuario;
using WEB.Models.Genero;
using WEB.Models.Aula;
using WEB.Models.Response;
using WEB.Models.Certifticado;

namespace WEB.Controllers {
    public class TurmaController(IConfiguration configuration) : Controller {
        public async Task<IActionResult> Index(int? cdTurma = null, bool? icAdicionar = false) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));

            ViewBag.CdTurma = cdTurma ?? -1;
            ViewBag.IcAdicionar = icAdicionar;

            var CursoViewModel = new CursoViewModel();
            var ListaCurso = await CursoViewModel.GerarLista(configuration);
            ViewBag.ListaCurso = ListaCurso.Data;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarTurmas(ListarTurmaViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoTurma(TurmaViewModel TurmaViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await TurmaViewModel.BuscarInfo(configuration);

            var ProfessorViewModel = new ProfessorViewModel();
            var ListaProfessor = await ProfessorViewModel.GerarLista(configuration);
            ViewBag.ListaProfessor = ListaProfessor.Data;

            var CursoViewModel = new CursoViewModel();
            var ListaCurso = await CursoViewModel.GerarLista(configuration);
            ViewBag.ListaCurso = ListaCurso.Data;

            return PartialView("_InfoTurma", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarTurma() {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var ProfessorViewModel = new ProfessorViewModel();
            var ListaProfessor = await ProfessorViewModel.GerarLista(configuration);
            ViewBag.ListaProfessor = ListaProfessor.Data;

            var CursoViewModel = new CursoViewModel();
            var ListaCurso = await CursoViewModel.GerarLista(configuration);
            ViewBag.ListaCurso = ListaCurso.Data;

            return PartialView("_AdicionarTurma");
        }

        public async Task<JsonResult> AdicionarTurma(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new TurmaViewModel().Adicionar(configuration, ResponseModelTurma);

            if (responseAdd.IsSuccess) {
                try {
                    byte[] byteCertificado = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/wwwroot/img/Modelo_Certificado.jpg");
                    var responseCertificado = await new CertificadoViewModel().AdicionarCertificadoTurma(configuration, responseAdd.Data.CdTurma, byteCertificado);
                } catch {
                    //buaa, não adicionou
                }
            }

            return Json(responseAdd);
        }

        [HttpPost]
        public async Task<bool> AtualizarInfoTurma(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new TurmaViewModel().AtualizarInfo(configuration, ResponseModelTurma);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<ActionResult> ReativarTurma(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new TurmaViewModel().Reativar(configuration, ResponseModelTurma));
        }

        [HttpPost]
        public async Task<ActionResult> DesativarTurma(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var response = await new TurmaViewModel().Desativar(configuration, ResponseModelTurma);

            var TurmaViewModel = new TurmaViewModel();
            TurmaViewModel.id = ResponseModelTurma.CdTurma;
            var infoTurma = await TurmaViewModel.BuscarInfo(configuration);

            return Json(new { response, infoTurma });
        }

        [HttpPost]
        public async Task<ActionResult> RetomarInscricao(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new TurmaViewModel().RetomarInscricao(configuration, ResponseModelTurma));
        }

        [HttpPost]
        public async Task<ActionResult> PararInscricao(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new TurmaViewModel().PararInscricao(configuration, ResponseModelTurma));
        }


        public async Task<IActionResult> CarregarAulasTurma(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var AulaViewModel = new AulaViewModel();
            var ListaAulas = await AulaViewModel.BuscarPorTurma(configuration, ResponseModelTurma);
            ViewBag.ListaAulas = ListaAulas.Data;

            return PartialView("_ListaAulas");
        }
        
        [HttpGet]
        public async Task<IActionResult> CarregarAlunosTurma(ResponseModelTurma ResponseModelTurma) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var AlunoViewModel = new AlunoViewModel();
            var ListaAlunos = await AlunoViewModel.BuscarPorTurma(configuration, ResponseModelTurma);
            ViewBag.ListaAlunos = ListaAlunos.Data;

            return PartialView("_ListaAlunos");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAula(ResponseModelAula ResponseModelAula) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var AulaViewModel = new AulaViewModel();
            AulaViewModel.CdAula = ResponseModelAula.cdAula;
            var InfoAula = await AulaViewModel.BuscarInfo(configuration);

            return PartialView("_InfoAula", InfoAula.Data);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarAdicionarAula() {
            return PartialView("_AdicionarAula");
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAula(ResponseModelAula ResponseModelAula) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new AulaViewModel().Adicionar(configuration, ResponseModelAula));
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirAula(ResponseModelAula ResponseModelAula) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new AulaViewModel().Excluir(configuration, ResponseModelAula));
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarInfoAula(ResponseModelAula ResponseModelAula) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new AulaViewModel().AtualizarInfo(configuration, ResponseModelAula));
        }

        [HttpDelete]
        public async Task<IActionResult> DesvincularAluno(TurmaAlunoViewModel TurmaAlunoViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await TurmaAlunoViewModel.DesvincularAluno(configuration));
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAluno(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var UsuarioViewModel = new UsuarioViewModel();
            UsuarioViewModel.DsCpf = ResponseModelUsuario.DsCpf;

            var InfoUsuario = await UsuarioViewModel.BuscarInfo(configuration);

            if (InfoUsuario.Data != null) {
                var AlunoViewModel = new AlunoViewModel();
                var TurmaAtual = await AlunoViewModel.BuscarTurmaAtual(configuration, InfoUsuario.Data);

                if (TurmaAtual.Data != null) {
                    ViewBag.NmTurma = TurmaAtual.Data.NmTurma;
                    ViewBag.NmCurso = TurmaAtual.Data.NmCurso;
                }
            }

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            return PartialView("_InfoAluno", InfoUsuario.Data);
        }
    }
}