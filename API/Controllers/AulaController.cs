using Application.Interfaces;
using Application.Requests.Aula;
using Application.Requests.Curso;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class AulaController(IAulaService aulaService) : ControllerBase {
        
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddAula([FromBody] AddAulaRequest request) {
            var result = await aulaService.AddAula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("api/[controller]/{aulaId:int}")]
        public async Task<ActionResult> UpdateAula(int aulaId, UpdateAulaRequest request) {
            if (aulaId != request.CdAula) return new BadRequestResult();
            var result = await aulaService.UpdateAula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]/GetAulasByTurmaId/{turmaId:int}")]
        public async Task<ActionResult> GetAulasByTurmaId(int turmaId, bool? icChamada,bool? icConteudo, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
            var request = new GetAulasByTurmaIdRequest(turmaId, icChamada,icConteudo, pageNumber,pageSize);
            var result = await aulaService.GetAulasByTurmaId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("api/[controller]")]
        public async Task<ActionResult> DeleteAula([FromBody] DeleteAulaRequest request) {
            var result = await aulaService.DeleteAula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]/GetAulaById/{aulaId:int}")]
        public async Task<ActionResult> GetAulaById(int aulaId) {
            var request = new GetAulaByIdRequest(aulaId);
            var result = await aulaService.GetAulaById(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
