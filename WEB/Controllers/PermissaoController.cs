using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json;
using WEB.Models;
using WEB.Models.Cargo;
using WEB.Models.Permissao;
using WEB.Models.PermissaoCargo;
using WEB.Models.Response;
using WEB.Models.Shared;
using WEB.Models.Usuario;

namespace WEB.Controllers {
    public class PermissaoController(IConfiguration configuration) : Controller {
        public IActionResult Index() {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));

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