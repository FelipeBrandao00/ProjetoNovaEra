using Application.Requests.Professor;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    public class ProfessorController(IProfessorService professorService) : ControllerBase
    {
        [HttpGet("api/[controller]/GetProfessores")]
        public async Task<ActionResult> GetProfessores([FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null,[FromQuery] string nmProfessor = "",[FromQuery] bool? icHabilitadoTurma = null) {
            var request = new GetProfessoresRequest(pageNumber, pageSize,nmProfessor,icHabilitadoTurma);
            var result = await professorService.GetProfessores(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        
        [HttpPost("api/[controller]/SetHabilitarProfessor")]
        public async Task<ActionResult> SetHabilitarProfessor(SetProfessorHabilitadoTurmaRequest request) {
            var result = await professorService.SetProfessorHabilitadoTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        
        [HttpPost("api/[controller]/SetDesabilitarProfessor")]
        public async Task<ActionResult> SetDesabilitarProfessor(SetProfessorDesabilitadoTurmaRequest request) {
            var result = await professorService.SetProfessorDesabilitadoTurma(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
