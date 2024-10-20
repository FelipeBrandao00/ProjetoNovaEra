using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.CargoUsuario;
using WEB.Models.Professor;
using WEB.Models.Shared;
using WEB.Models.Usuario;

namespace WEB.Controllers
{
    public class ProfessorController(IConfiguration configuration) : Controller {
        public IActionResult Index(bool icAdicionar = false) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));

            ViewBag.IcAdicionar = icAdicionar;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarProfessores(ListarProfessorViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoProfessor(UsuarioViewModel UsuarioViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await UsuarioViewModel.BuscarInfo(configuration);
            return PartialView("_InfoProfessor", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarProfessor() {
            return PartialView("_AdicionarProfessor", null);
        }

        public async Task<IActionResult> AdicionarProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new UsuarioViewModel().Adicionar(configuration, ResponseModelUsuario);
            var resposeCargo = await new CargoUsuarioViewModel().AddCargoUsuario(configuration, responseAdd.Data.CdUsuario, 2);

            return PartialView("_InfoProfessor", responseAdd.Data);
        }

        [HttpPost]
        public async Task<bool> AtualizarInfoProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> HabilitarProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new ProfessorViewModel().Habilitar(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }

        [HttpPost]
        public async Task<bool> DesabilitarProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var response = await new ProfessorViewModel().Desabilitar(configuration, ResponseModelUsuario);
            return response.IsSuccess;
        }
    }
}