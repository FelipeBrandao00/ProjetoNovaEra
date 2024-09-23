using Application.Interfaces;
using Application.Requests.Cargos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Authorize(Roles = "Administrador")]
    [ApiController]
    public class AlunoController(IAlunoService alunoService) : ControllerBase {
        [HttpGet("api/[controller]/GetAllTurmasByUsuarioId/{cdUsuario:guid}")]
        public async Task<ActionResult> GetAllTurmasByUsuarioId(Guid cdUsuario, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
            var request = new GetAllTurmasByUsuarioIdRequest(cdUsuario, pageNumber, pageSize);
            var result = await alunoService.GetAllTurmasByUsuarioId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]/GetAtualTurmaByUsuarioId/{cdUsuario:guid}")]
        public async Task<ActionResult> GetAtualTurmaByUsuarioId(Guid cdUsuario) {
            var request = new GetAtualTurmaByUsuarioIdRequest(cdUsuario);
            var result = await alunoService.GetAtualTurmaByUsuarioId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        
        [HttpGet("api/[controller]/GetAlunoByLikedName/{nome}")]
        public async Task<ActionResult> GetAlunoByLikedName(string nome, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
            var request = new GetAlunoByLikedNameRequest(nome, pageNumber, pageSize);
            var result = await alunoService.GetAlunoByLikedName(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
