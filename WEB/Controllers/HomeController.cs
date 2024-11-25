using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Cargo;
using System.Linq;
using WEB.Models.PermissaoCargo;

namespace WEB.Controllers;

public class HomeController(IConfiguration configuration) : Controller {

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
        ViewBag.Roles = dados.role;
        ViewBag.ListaPermissoes = hashPermissoes;
        return View();
    }

    public IActionResult Sair()
    {
        Response.Cookies.Delete("Token");
        return RedirectToAction("Index", "Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}