using Application.Interfaces;
using Application.Requests.Conteudo;
using Application.Requests.Curso;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Authorize(Roles = "Administrador, Master, Professor")]
    [ApiController]
    public class ConteudoController(IConteudoService _service) : ControllerBase {
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddConteudo(AddConteudoRequest request) {
            var result = await _service.AddConteudo(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("api/[controller]/{id:int}")]
        public async Task<ActionResult> UpdateConteudo(int id, UpdateConteudoRequest request) {
            if (id != request.CdConteudo) return new BadRequestResult();
            var result = await _service.UpdateConteudo(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]/{id:int}")]
        public async Task<ActionResult> GetConteudoById(int id) {
            var request = new GetConteudoByIdRequest() { CdConteudo = id };
            var result = await _service.GetConteudoById(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]/GetConteudosByAulaId/{aulaId:int}")]
        public async Task<ActionResult> GetConteudosByAulaId(int aulaId,[FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
            var request = new GetConteudosByAulaIdRequest(aulaId, pageNumber, pageSize);
            var result = await _service.GetConteudosByAulaId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("api/[controller]")]
        public async Task<ActionResult> DeleteConteudo([FromBody] DeleteConteudoRequest request) {
            var result = await _service.DeleteConteudo(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
