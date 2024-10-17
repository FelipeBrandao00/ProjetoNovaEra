using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text.Json;
using WEB.Models;
using WEB.Models.Aluno;
using WEB.Models.EsqueciSenha;
using WEB.Models.Genero;
using WEB.Models.Shared;
using WEB.Models.Usuario;

namespace WEB.Controllers
{
    public class AlunoController(IConfiguration configuration) : Controller
    {
        public IActionResult Index()
        {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarAlunos(ListarAlunoViewModel model)
        {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAluno(UsuarioViewModel UsuarioViewModel)
        {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var InfoUsuario = await UsuarioViewModel.BuscarInfo(configuration);

            if(InfoUsuario.Data != null)
            {
                var AlunoViewModel = new AlunoViewModel();
                var TurmaAtual = await AlunoViewModel.BuscarTurmaAtual(configuration, InfoUsuario.Data);

                if(TurmaAtual.Data != null) {
                    ViewBag.NmTurma = TurmaAtual.Data.DsTurma;
                    ViewBag.NmCurso = TurmaAtual.Data.NmCurso;
                }
            }

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            return PartialView("_InfoAluno", InfoUsuario.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarInfoAluno([FromForm] ResponseModelUsuario ResponseModelUsuario, IFormFile DsFoto)
        {
            //Validação da imagem
            if (DsFoto != null)
            {
                if (!DsFoto.ContentType.StartsWith("image/"))
                    return Json(new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no formato da foto enviada." });

                using (var memoryStream = new MemoryStream()) {
                    await DsFoto.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    ResponseModelUsuario.DsFoto = imageBytes;
                }
            }

            //Atualiza as informações de fato
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario));
        }
    }
}