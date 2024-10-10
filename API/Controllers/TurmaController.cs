using Application.Interfaces;
using Application.Requests.Curso;
using Application.Requests.Turma;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Authorize(Roles = "Administrador")]
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
            if (id != request.CdCurso) return new BadRequestResult();
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
        public async Task<ActionResult> GetTurmas([FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
            var request = new GetTurmasRequest(pageNumber, pageSize);
            var result = await turmaService.GetTurmas(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        //[HttpDelete("api/[controller]")]
        //public async Task<ActionResult> DeleteCurso([FromBody] DeleteCursoRequest request) {
        //    var result = await turmaService.DeleteCurso(request);
        //    if (!result.IsSuccess) return BadRequest(result);
        //    return Ok(result);
        //}

        [HttpPost("api/[controller]/DesativarTurma")]
        public async Task<ActionResult> DesativarTurma([FromBody] FinalizarTurmaRequest request) {
            var result = await turmaService.FinalizarTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("api/[controller]/ReativarCurso")]
        public async Task<ActionResult> ReativarTurma([FromBody] ReativarTurmaRequest request) {
            var result = await turmaService.ReativarTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
