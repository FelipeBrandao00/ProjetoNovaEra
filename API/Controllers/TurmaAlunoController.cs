using Application.Interfaces;
using Application.Requests.CargoUsuario;
using Application.Requests.TurmaAluno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Authorize(Roles = "Administrador, Master, Professor")]
    public class TurmaAlunoController(ITurmaAlunoService turmaAlunoService) : ControllerBase {
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddTurmaAluno(AddTurmaAlunoRequest request) {
            var result = await turmaAlunoService.AddTurmaAluno(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("api/[controller]")]
        public async Task<ActionResult> DeleteTurmaAluno(DeleteTurmaAlunoRequest request) {
            var result = await turmaAlunoService.DeleteTurmaAluno(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
