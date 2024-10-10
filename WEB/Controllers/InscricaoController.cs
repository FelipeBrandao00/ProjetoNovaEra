using Microsoft.AspNetCore.Mvc;
using WEB.Models.Inscricao;

namespace WEB.Controllers {
    public class InscricaoController(IConfiguration configuration) : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarInscricao(InscricaoViewModel model) {
            //await model.GerarLista(configuration);
            //faz a logica de confirmar a insc aqui
            return View();
        }
    }
}
