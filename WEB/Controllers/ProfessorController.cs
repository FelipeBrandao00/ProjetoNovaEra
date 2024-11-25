using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.CargoUsuario;
using WEB.Models.Professor;
using WEB.Models.Genero;
using WEB.Models.Shared;
using WEB.Models.Usuario;
using WEB.Models.PermissaoCargo;
using WEB.Models.Cargo;

namespace WEB.Controllers
{
    public class ProfessorController(IConfiguration configuration) : Controller {
        public IActionResult Index(bool icAdicionar = false) {
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

            ViewBag.IcAdicionar = icAdicionar;
            ViewBag.Roles = dados.role;
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

            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            return PartialView("_InfoProfessor", response.Data);
        }

        public async Task<IActionResult> CarregarAdicionarProfessor() {
            configuration["JwtToken"] = Request.Cookies["Token"];
            var GeneroViewModel = new GeneroViewModel();
            var ListaGenero = await GeneroViewModel.GerarLista(configuration);
            ViewBag.ListaGenero = ListaGenero.Data;

            return PartialView("_AdicionarProfessor", null);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProfessor([FromForm] ResponseModelUsuario ResponseModelUsuario, IFormFile DsFoto) {
            
            //Validação da imagem
            if (DsFoto != null)
            {
                if (!DsFoto.ContentType.StartsWith("image/"))
                    return Json(new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no formato da foto enviada." });

                using (var memoryStream = new MemoryStream())
                {
                    await DsFoto.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    ResponseModelUsuario.DsFoto = imageBytes;
                }
            }

            //Adiciona o professor de fato
            configuration["JwtToken"] = Request.Cookies["Token"];
            var responseAdd = await new UsuarioViewModel().Adicionar(configuration, ResponseModelUsuario);
            if (!responseAdd.IsSuccess)
                return Json(responseAdd);

            var resposeCargo = await new CargoUsuarioViewModel().AddCargoUsuario(configuration, (responseAdd.Data?.CdUsuario ?? new Guid()), 2);
            if (!resposeCargo.IsSuccess)
                return Json(resposeCargo);

            return Json(responseAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarInfoProfessor([FromForm] ResponseModelUsuario ResponseModelUsuario, IFormFile DsFoto) {

            //Validação da imagem
            if (DsFoto != null)
            {
                if (!DsFoto.ContentType.StartsWith("image/"))
                    return Json(new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no formato da foto enviada." });

                using (var memoryStream = new MemoryStream())
                {
                    await DsFoto.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    ResponseModelUsuario.DsFoto = imageBytes;
                }
            }

            //Atualiza as informações de fato
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new UsuarioViewModel().AtualizarInfo(configuration, ResponseModelUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> HabilitarProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new ProfessorViewModel().Habilitar(configuration, ResponseModelUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> DesabilitarProfessor(ResponseModelUsuario ResponseModelUsuario) {
            configuration["JwtToken"] = Request.Cookies["Token"];
            return Json(await new ProfessorViewModel().Desabilitar(configuration, ResponseModelUsuario));
        }
    }
}