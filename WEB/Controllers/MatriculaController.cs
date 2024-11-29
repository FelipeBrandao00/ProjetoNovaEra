using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Response;
using WEB.Models.Turma;
using WEB.Models.Aluno;
using WEB.Models.Matricula;
using WEB.Models.Genero;
using WEB.Models.PermissaoCargo;
using WEB.Models.Cargo;
using Application.Responses;

namespace WEB.Controllers {
    public class MatriculaController(IConfiguration configuration) : Controller {
        public async Task<IActionResult> Index() {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            dynamic? dados;
            try {
                dados = JwtToken.DescriptografarJwt(token);
            } catch (Exception) {
                dados = JwtTokenUnique.DescriptografarJwt(token);
            }

            if (dados.role is string) {
                ViewBag.Role = dados.role;
            } else {
                ViewBag.Role = String.Join(" | ", dados.role);
            }

            if (Function.spacesString(dados.unique_name) > 1) {
                ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ")[0]);
            } else {
                ViewBag.Nome = dados.unique_name;
            }

            configuration["JwtToken"] = Request.Cookies["Token"];
            var CargoViewModel = new CargoViewModel();
            var ListaCargos = CargoViewModel.GerarLista(configuration).Result.Data;


            var hashPermissoes = new HashSet<string>();
            if (ListaCargos.Any()) {
                if (dados.role is List<string>) {
                    foreach (var role in dados.role) {
                        if (ListaCargos.Any(x => x.DsCargo.Contains(role))) {
                            var cdCargo = ListaCargos.Where(x => x.DsCargo == role).Select(x => x.CdCargo).FirstOrDefault();
                            var lstPermissoesCargo = new PermissaoCargoViewModel().BuscarPermissoesCargo(configuration, cdCargo).Result.Data;

                            foreach (var item in lstPermissoesCargo) {
                                if (!hashPermissoes.Contains(item.NmPermissao)) {
                                    hashPermissoes.Add(item.NmPermissao);
                                }
                            }

                            if (lstPermissoesCargo.Count == 7) {
                                break;
                            }
                        }
                    }
                } else {
                    if (ListaCargos.Any(x => x.DsCargo.Contains(dados.role))) {
                        var cdCargo = ListaCargos.Where(x => x.DsCargo == dados.role).Select(x => x.CdCargo).FirstOrDefault();
                        var lstPermissoesCargo = new PermissaoCargoViewModel().BuscarPermissoesCargo(configuration, cdCargo).Result.Data;

                        foreach (var item in lstPermissoesCargo) {
                            if (!hashPermissoes.Contains(item.NmPermissao)) {
                                hashPermissoes.Add(item.NmPermissao);
                            }
                        }
                    }
                }
            }
            ViewBag.ListaPermissoes = hashPermissoes;

            var TurmaViewModel = new TurmaViewModel();
            var ListaTurmasAbertasMatricula = await TurmaViewModel.TurmasAbertasMatricula(configuration);
            ViewBag.ListaTurmasAbertasMatricula = ListaTurmasAbertasMatricula.Data;

            ViewBag.LinkInscricao = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/Inscricao";
            ViewBag.Roles = dados.role;
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
            

            var ResponseModelTurma = new ResponseModelTurma { 
                CdTurma = ResponseModelMatricula.cdTurma 
            };
            var AlunoViewModel = new AlunoViewModel();
            var ListaAlunos = await AlunoViewModel.BuscarPorTurma(configuration, ResponseModelTurma);
            ViewBag.QuantidadeMatriculados = ListaAlunos.Data?.Count();
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