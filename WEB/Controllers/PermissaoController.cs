using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WEB.Models;
using WEB.Models.Cargo;
using WEB.Models.Permissao;
using WEB.Models.PermissaoCargo;
using WEB.Models.Shared;

namespace WEB.Controllers {
    public class PermissaoController(IConfiguration configuration) : Controller {
        public IActionResult Index() {
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

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarCargos(ListarCargoViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoCargo(int CdCargo) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var PermissaoCargoViewModel = new PermissaoCargoViewModel();
            var ListaPermissoesCargo = await PermissaoCargoViewModel.BuscarPermissoesCargo(configuration, CdCargo);
            ViewBag.ListaPermissoesCargo = ListaPermissoesCargo.Data;

            var PermissaoViewModel = new PermissaoViewModel();
            var ListaPermissoes = await PermissaoViewModel.BuscarPermissoes(configuration);
            ViewBag.ListaPermissoes = ListaPermissoes.Data;

            var CargoViewModel = new CargoViewModel();
            var InfoCargo = await CargoViewModel.GerarLista(configuration);
            ViewBag.NmCargo = InfoCargo.Data.Where(x => x.CdCargo == CdCargo).First().DsCargo;
            ViewBag.CdCargo = CdCargo;

            return PartialView("_InfoPermissao");
        }

        [HttpPost]
        public async Task<ActionResult> AtualizarPermissoesCargo(string StrPermissao, int cdCargo) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            int[] permissoesArray = JsonSerializer.Deserialize<string[]>(StrPermissao).Select(int.Parse).ToArray();

            var responseAdd = await new PermissaoCargoViewModel().AddPermissoesCargo(configuration, cdCargo, permissoesArray);
            return Json(responseAdd);
        }
    }
}