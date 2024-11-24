﻿using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Shared;
using WEB.Models.Curso;
using WEB.Models.Turma;
using WEB.Models.Aula;
using System.Collections.Generic;
using WEB.Models.Response;
using WEB.Models.CadastroConteudo;
using WEB.Models.Usuario;

namespace WEB.Controllers {
    public class CadastroConteudoController(IConfiguration configuration) : Controller {

        public async Task<IActionResult> Index(bool icAdicionar = false) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            var dados = JwtToken.DescriptografarJwt(token);
            ViewBag.Role = String.Join(" | ", dados.role);
            ViewBag.Nome = String.Join(" ", dados.unique_name.Split(" ").Take(2));

            ViewBag.IcAdicionar = icAdicionar;

            var ListarTurmaViewModel = new ListarTurmaViewModel() {
                IcFinalizado = false
            };
            configuration["JwtToken"] = token;
            await ListarTurmaViewModel.GerarLista(configuration);
            ViewBag.ListaTurma = ListarTurmaViewModel.ItensLista;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarAulas(ResponseModelTurma ResponseModelTurma, bool? icConteudo) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var retorno = await new AulaViewModel().BuscarPorTurma(configuration, ResponseModelTurma, icConteudo: icConteudo);
            ViewBag.ListaAula = retorno.Data;
            return View("_ListaAulas");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAula(AulaViewModel AulaViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var InfoAula = await AulaViewModel.BuscarInfo(configuration);

            var ListaConteudo = await new CadastroConteudoViewModel() {
                CdAula = AulaViewModel.CdAula
            }.ListarConteudo(configuration);
            ViewBag.ListaConteudo = ListaConteudo.Data;

            return View("_InfoAula", InfoAula.Data ?? new ResponseModelAula());
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConteudo(CadastroConteudoViewModel CadastroConteudoViewModel)
        {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await CadastroConteudoViewModel.Excluir(configuration));
        }

        [HttpGet]
        public async Task<IActionResult> CarregarAdicionarArquivo() {
            return View("_AdicionarArquivo");
        }

    }
}