using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Aluno;
using WEB.Models.Aula;
using WEB.Models.Chamada;
using WEB.Models.PermissaoCargo;
using WEB.Models.Response;
using WEB.Models.Shared;
using WEB.Models.Cargo;

namespace WEB.Controllers
{
    public class ChamadaController(IConfiguration configuration) : Controller {
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
                ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));
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

            var model = new ListarTurmaViewModel();
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