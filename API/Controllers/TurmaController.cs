using Application.Interfaces;
using Application.Requests.Turma;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Authorize(Roles = "Administrador, Professor, Master")]
    [ApiController]
    public class TurmaController(ITurmaService turmaService) : ControllerBase {
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddTurma([FromBody] AddTurmaRequest request) {
            var result = await turmaService.AddTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("api/[controller]/{id:int}")]
        public async Task<ActionResult> UpdateTurma(int id, UpdateTurmaRequest request) {
            if (id != request.CdTurma) return new BadRequestResult();
            var result = await turmaService.UpdateTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]/{id:int}")]
        public async Task<ActionResult> GetTurmaById(int id) {
            var request = new GetTurmaByIdRequest() { CdTurma = id };
            var result = await turmaService.GetTurmaById(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]")]
        public async Task<ActionResult> GetTurmas(
            [FromQuery] string nome = "", 
            [FromQuery] DateTime? dtInicial = null, 
            [FromQuery] DateTime? dtFinal = null, 
            [FromQuery] bool? icFinalizado = null, 
            [FromQuery] int? cursoId = null,
            [FromQuery] Guid? professorId = null,
            [FromQuery] int? pageNumber = null,
            [FromQuery] int? pageSize = null) {
            var request = new GetTurmasRequest(nome,pageNumber,pageSize,dtInicial,dtFinal,icFinalizado,cursoId, professorId);
            var result = await turmaService.GetTurmas(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("api/[controller]/DesativarTurma")]
        public async Task<ActionResult> DesativarTurma([FromBody] FinalizarTurmaRequest request) {
            var result = await turmaService.FinalizarTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("api/[controller]/ReativarTurma")]
        public async Task<ActionResult> ReativarTurma([FromBody] ReativarTurmaRequest request) {
            var result = await turmaService.ReativarTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("api/[controller]/HabilitarMatricula")]
        public async Task<ActionResult> HabilitarMatricula([FromBody] HabilitarMatriculaRequest request) {
            var result = await turmaService.HabilitarMatricula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("api/[controller]/EncerrarMatricula")]
        public async Task<ActionResult> EncerrarMatricula([FromBody] EncerrarMatriculaRequest request) {
            var result = await turmaService.EncerrarMatricula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("api/[controller]/GetTurmasAbertaMatricula")]
        public async Task<ActionResult> GetTurmasAbertaMatricula()
        {
            var request = new GetTurmasAbertaMatriculaRequest() { };
            var result = await turmaService.GetTurmasAbertaMatricula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
