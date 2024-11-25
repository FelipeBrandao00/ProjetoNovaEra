using Application.Interfaces;
using Application.Requests.Curso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Administrador, Master, Professor")]
[ApiController]
public class CursoController(ICursoService cursoService) : ControllerBase {
    [HttpPost("api/[controller]")]
    public async Task<ActionResult> AddCurso([FromBody] CreateCursoRequest request) {
        var result = await cursoService.AddCurso(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpPut("api/[controller]/{id:int}")]
    public async Task<ActionResult> UpdateCurso(int id, UpdateCursoRequest request) {
        if (id != request.CdCurso) return new BadRequestResult();
        var result = await cursoService.UpdateCurso(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("api/[controller]/{id:int}")]
    public async Task<ActionResult> GetCursoById(int id) {
        var request = new GetCursoByidRequest() { CdCurso = id };
        var result = await cursoService.GetCursoByid(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("api/[controller]")]
    public async Task<ActionResult> GetCursos([FromQuery] string nome = "", [FromQuery] DateTime? dtInicial = null, [FromQuery] DateTime? dtFinal = null, [FromQuery] bool? icFinalizado = null, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
        var request = new GetCursosRequest(nome, pageNumber, pageSize, dtInicial, dtFinal, icFinalizado);
        var result = await cursoService.GetCursos(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpDelete("api/[controller]")]
    public async Task<ActionResult> DeleteCurso([FromBody] DeleteCursoRequest request) {
        var result = await cursoService.DeleteCurso(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("api/[controller]/DesativarCurso")]
    public async Task<ActionResult> DesativarCurso([FromBody] FinishCursoByidRequest request) {
        var result = await cursoService.FinalizarCurso(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("api/[controller]/ReativarCurso")]
    public async Task<ActionResult> ReativarCurso([FromBody] ReactivateCursoByidRequest request) {
        var result = await cursoService.ReativarCurso(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}