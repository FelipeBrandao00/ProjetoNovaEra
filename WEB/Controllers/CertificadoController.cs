using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Security.Cryptography.Xml;
using WEB.Models;
using WEB.Models.Aluno;
using WEB.Models.Certifticado;
using WEB.Models.Genero;
using WEB.Models.Shared;
using WEB.Models.Turma;
using WEB.Models.Usuario;

namespace WEB.Controllers {
    public class CertificadoController(IConfiguration configuration) : Controller {
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
        public async Task<IActionResult> ListarAlunos(ListarAlunoViewModel model) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            await model.GerarLista(configuration);
            return PartialView("_ListarPadrao", model);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAluno(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var UsuarioViewModel = new UsuarioViewModel();
            UsuarioViewModel.DsCpf = ResponseModelUsuario.DsCpf;
            var InfoUsuario = await UsuarioViewModel.BuscarInfo(configuration);

            var ListaTurmasAluno = await new AlunoViewModel().BuscarTodasAsTurmas(configuration, InfoUsuario.Data.CdUsuario);
            ViewBag.ListaTurmasAluno = ListaTurmasAluno.Data;
            ViewBag.QuantidadeTurmas = ListaTurmasAluno.Data?.Count;

            return PartialView("_InfoCertificado", InfoUsuario.Data);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarCertificado(ResponseModelTurma ResponseModelTurma, ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var InfoCertificado = await new CertificadoViewModel().BuscarCertificadoTurma(configuration, ResponseModelTurma.CdTurma);

            var TurmaViewModel = new TurmaViewModel();
            TurmaViewModel.id = ResponseModelTurma.CdTurma;
            var InfoTurma = TurmaViewModel.BuscarInfo(configuration);

            var CertificadoImg = Certificado.Gerar(InfoCertificado?.Data?.arquivo, 
                ResponseModelUsuario?.NmUsuario, InfoTurma?.Result?.Data?.DtFim,
                InfoTurma?.Result?.Data?.NmTurma); 

            ViewBag.CertificadoImg = CertificadoImg;
            ViewBag.StringCertificado = Convert.ToBase64String(CertificadoImg);
            ViewBag.IcExiste = (CertificadoImg != null && CertificadoImg.Length > 0);

            ViewBag.NmUsuario = ResponseModelUsuario.NmUsuario;
            return PartialView("_CertificadoView");
        }

        [HttpPost]
        public async Task<IActionResult> DownloadCertificado(ResponseModelTurma ResponseModelTurma, ResponseModelUsuario ResponseModelUsuario, string certificado) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var TurmaViewModel = new TurmaViewModel();
            TurmaViewModel.id = ResponseModelTurma.CdTurma;
            var InfoTurma = TurmaViewModel.BuscarInfo(configuration);

            byte[] buffer = Convert.FromBase64String(certificado);

            return File(buffer, "image/jpeg", $"Certificado_{ResponseModelUsuario?.NmUsuario}.jpg");
        }

        [HttpPost]
        public async Task<JsonResult> EncaminharEmail(string TxtEmail, string certificado) {
            configuration["JwtToken"] = Request.Cookies["Token"];

            byte[] buffer = Convert.FromBase64String(certificado);

            return Json(await Certificado.EnviarEmail(TxtEmail, buffer));
        }
    }
}