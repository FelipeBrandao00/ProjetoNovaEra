using Application.Interfaces;
using Application.Requests.Permissao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Administrador, Master, Professor")]
    public class PermissaoController(IPermissaoService permissaoService) : ControllerBase
    {
        [HttpGet("api/[controller]")]
        public async Task<ActionResult> GetCargos([FromQuery]int? pageNumber = null,[FromQuery]int? pageSize = null)
        {
            var request = new GetAllPermissoesRequest(pageNumber, pageSize);
            var result = await permissaoService.GetPermissoes(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
