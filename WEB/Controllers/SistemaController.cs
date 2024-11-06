using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.CargoUsuario;
using WEB.Models.Professor;
using WEB.Models.Shared;
using WEB.Models.Usuario;
using WEB.Models.Genero;
using WEB.Models.Cargo;
using WEB.Models.Response;
using WEB.Models.Curso;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace WEB.Controllers {
    public class SistemaController(IConfiguration configuration) : Controller {
        public async Task<IActionResult> Index(bool icAdicionar = false) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));

            ViewBag.IcAdicionar = icAdicionar;

            configuration["JwtToken"] = token;
            var CargoViewModel = new CargoViewModel();
            var ListaCargo = await CargoViewModel.GerarLista(configuration);
            ViewBag.ListaCargo = ListaCargo.Data;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios(ListarUsuarioViewModel model, string StrCargos) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            model.LstCargos = JsonSerializer.Deserialize<string[]>(StrCargos.Replace("ck", "")).Select(int.Parse).ToList();

            await model.GerarLista(configuration);

            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoUsuario(UsuarioViewModel UsuarioViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await UsuarioViewModel.BuscarInfo(configuration);

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;
            
            var CargoUsuarioViewModel = new CargoUsuarioViewModel();
            var ListaCargosUsuario = await CargoUsuarioViewModel.ListarCargoUsuario(configuration, response.Data.CdUsuario);
            ViewBag.ListaCargosUsuario = ListaCargosUsuario.Data;

            var CargoViewModel = new CargoViewModel();
            var ListaCargos = await CargoViewModel.GerarLista(configuration);
            ViewBag.ListaCargos = ListaCargos.Data;

            return PartialView("_InfoUsuario", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarUsuario() {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            var CargoViewModel = new CargoViewModel();
            var ListaCargos = await CargoViewModel.GerarLista(configuration);
            ViewBag.ListaCargos = ListaCargos.Data;

            return PartialView("_AdicionarUsuario", null);
        }

        public async Task<IActionResult> AdicionarUsuario([FromForm] ResponseModelUsuario ResponseModelUsuario, IFormFile DsFoto, string StrCargos) {
            if (DsFoto != null) {
                if (!DsFoto.ContentType.StartsWith("image/"))
                    return Json(new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no formato da foto enviada." });

                using (var memoryStream = new MemoryStream()) {
                    await DsFoto.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    ResponseModelUsuario.DsFoto = imageBytes;
                }
            }

            int[] cargosArray = JsonSerializer.Deserialize<string[]>(StrCargos).Select(int.Parse).ToArray();

            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new UsuarioViewModel().Adicionar(configuration, ResponseModelUsuario);
            if (!responseAdd.IsSuccess)
                return Json(responseAdd);

            var resposeCargo = await new CargoUsuarioViewModel().AddCargosUsuario(configuration, responseAdd.Data.CdUsuario, cargosArray);
            if (!resposeCargo.IsSuccess)
                return Json(resposeCargo);

            return Json(responseAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarInfoUsuario([FromForm] ResponseModelUsuario ResponseModelUsuario, IFormFile DsFoto, string StrCargos) {
            if (DsFoto != null) {
                if (!DsFoto.ContentType.StartsWith("image/"))
                    return Json(new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no formato da foto enviada." });

                using (var memoryStream = new MemoryStream()) {
                    await DsFoto.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    ResponseModelUsuario.DsFoto = imageBytes;
                }
            }

            int[] cargosArray = JsonSerializer.Deserialize<string[]>(StrCargos).Select(int.Parse).ToArray();

            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario);
            if (!responseAdd.IsSuccess)
                return Json(responseAdd);

            var responseCargo = await new CargoUsuarioViewModel().AddCargosUsuario(configuration, responseAdd.Data.CdUsuario, cargosArray);
            if (!responseCargo.IsSuccess)
                return Json(responseAdd);

            return Json(responseAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AtivarUsuario(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new ProfessorViewModel().Habilitar(configuration, ResponseModelUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> InativarUsuario(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new ProfessorViewModel().Desabilitar(configuration, ResponseModelUsuario));
        }
    }
}