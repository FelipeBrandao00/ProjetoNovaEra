using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Shared;
using WEB.Models.Curso;
using WEB.Models.PermissaoCargo;
using WEB.Models.Cargo;

namespace WEB.Controllers {
    public class CursoCOntroller(IConfiguration configuration) : Controller {
        public IActionResult Index(bool icAdicionar = false) {
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
        public async Task<bool> ReativarCurso(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().Reativar(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> FinalizarCurso(ResponseModelCurso ResponseModelCurso) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new CursoViewModel().Finalizar(configuration, ResponseModelCurso);
            return response.IsSuccess;
        }
    }
}