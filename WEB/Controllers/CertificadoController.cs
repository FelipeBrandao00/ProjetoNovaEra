using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.Aluno;
using WEB.Models.Certifticado;
using WEB.Models.PermissaoCargo;
using WEB.Models.Shared;
using WEB.Models.Turma;
using WEB.Models.Usuario;
using WEB.Models.Cargo;

namespace WEB.Controllers
{
    public class CertificadoController(IConfiguration configuration) : Controller {
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
            ViewBag.ListaPermissoes = hashPermissoes;
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