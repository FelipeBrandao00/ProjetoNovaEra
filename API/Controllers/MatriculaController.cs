using Application.Interfaces;
using Application.Requests.Aula;
using Application.Requests.Matricula;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class MatriculaController(IMatriculaService matriculaService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddMatricula([FromBody] AddMatriculaRequest request)
        {
            var result = await matriculaService.AddMatricula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }


        [HttpGet("api/[controller]/GetMatriculasByTurmaId/{turmaId:int}")]
        public async Task<ActionResult> GetMatriculasByTurmaId(int turmaId, [FromQuery] int idadeInicial, [FromQuery] int idadeFinal, bool? IcExAluno)
        {
            var request = new GetMatriculasByTurmaIdRequest(turmaId);
            var result = await matriculaService.GetMatriculasByTurmaId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]/GetMatriculaById/{matriculaId:int}")]
        public async Task<ActionResult> GetMatriculaById(int matriculaId)
        {
            var request = new GetMatriculaByIdRequest { CdMatricula = matriculaId };
            var result = await matriculaService.GetMatriculaById(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("api/[controller]/EfetivarMatriculas")]
        public async Task<ActionResult> EfetivarMatriculas(EfetivarMatriculasRequest request)
        {
            var result = await matriculaService.EfetivarMatriculas(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
