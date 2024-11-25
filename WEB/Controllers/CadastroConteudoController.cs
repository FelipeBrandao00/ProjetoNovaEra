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
using WEB.Models.Cargo;
using WEB.Models.PermissaoCargo;
using Application.Responses;

namespace WEB.Controllers {
    public class CadastroConteudoController(IConfiguration configuration) : Controller {

        public async Task<IActionResult> Index(bool icAdicionar = false, int? cdAula = null, int? cdTurma = null) {
            string? token = Request.Cookies["Token"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }
            
            ViewBag.IcAdicionar = icAdicionar;
            ViewBag.CdAula = cdAula ?? -1;
            ViewBag.CdTurma = cdTurma ?? -1;

            var ListarTurmaViewModel = new ListarTurmaViewModel() {
                IcFinalizado = false
            };
            configuration["JwtToken"] = token;
            await ListarTurmaViewModel.GerarLista(configuration);
            ViewBag.ListaTurma = ListarTurmaViewModel.ItensLista;

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

            Guid? cdProfessor = null;
            if (dados.role.Contains("Professor") && !(dados.role.Contains("Administrador") || dados.role.Contains("Master"))) {
                var responseUser = await new UsuarioViewModel().BuscarInfoEmail(configuration, dados.email);
                cdProfessor = responseUser.Data.CdUsuario;
            }
            ViewBag.Roles = dados.role;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarAulas(ResponseModelTurma ResponseModelTurma, bool? icConteudo) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var retorno = await new AulaViewModel().BuscarPorTurma(configuration, ResponseModelTurma, icConteudo: icConteudo);

            ViewBag.CdTurma = ResponseModelTurma.CdTurma;
            ViewBag.ListaAula = retorno.Data;
            return View("_ListaAulas");
        }

        [HttpGet]
        public async Task<IActionResult> CarregarInfoAula(AulaViewModel AulaViewModel) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var InfoAula = await AulaViewModel.BuscarInfo(configuration);

            var ListaConteudo = await new CadastroConteudoViewModel() {
                CdAula = AulaViewModel.CdAula
            }.Listar(configuration);
            ViewBag.ListaConteudo = ListaConteudo.Data;

            return View("_InfoAula", InfoAula.Data ?? new ResponseModelAula());
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConteudo(CadastroConteudoViewModel CadastroConteudoViewModel)
        {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await CadastroConteudoViewModel.Excluir(configuration));
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarConteudo([FromForm] CadastroConteudoViewModel CadastroConteudoViewModel, IFormFile DsArquivo)
        {
            //Validação do arquivo
            if (DsArquivo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await DsArquivo.CopyToAsync(memoryStream);
                    byte[] arquivoBytes = memoryStream.ToArray();
                    CadastroConteudoViewModel.ArquivoBytes = arquivoBytes;
                    CadastroConteudoViewModel.Arquivo = DsArquivo;
                }
            }

            //Atualiza as informações de fato
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await CadastroConteudoViewModel.Adicionar(configuration));
        }

        private static async Task<string> SalvarArquivoNaPastaDownloadsAsync(ResponseModelConteudo conteudo)
        {
            // Converte o Base64 em um array de bytes
            byte[] arquivoBytes = Convert.FromBase64String(conteudo.arquivo);

            // Obtém o caminho padrão da pasta Downloads do usuário
            string pastaDownloads = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads"
            );

            // Monta o caminho completo para salvar o arquivo
            string caminhoCompleto = Path.Combine(pastaDownloads, conteudo.nmArquivo + conteudo.dsExtensao);

            // Salva o arquivo de forma assíncrona usando FileStream
            using (var fileStream = new FileStream(caminhoCompleto, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                await fileStream.WriteAsync(arquivoBytes, 0, arquivoBytes.Length);
            }

            return $" \r\nSalvo em Downloads.";
        }

        [HttpPost]
        public async Task<IActionResult> DownloadConteudo(CadastroConteudoViewModel CadastroConteudoViewModel)
        {
            configuration["JwtToken"] = Request.Cookies["Token"];

            var infoConteudo = await CadastroConteudoViewModel.Buscar(configuration);

            // Agora o Download ocorre no lado cliente.
            /*
            if(infoConteudo.Data != null && !string.IsNullOrEmpty(infoConteudo.Data?.arquivo))
                infoConteudo.Message += await SalvarArquivoNaPastaDownloadsAsync(infoConteudo.Data);
            */

            infoConteudo.Message += " \r\nAguarde o download...";

            return Json(infoConteudo);
        }

        [HttpGet]
        public async Task<IActionResult> CarregarAdicionarArquivo() {
            return View("_AdicionarArquivo");
        }

    }
}