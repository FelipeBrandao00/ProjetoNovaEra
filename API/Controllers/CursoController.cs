using Application.Interfaces;
using Application.Requests.Curso;
using Application.Requests.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
public class CursoController(ICursoService cursoService) : ControllerBase
{
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
    public async Task<ActionResult> GetCursos([FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
        var request = new GetCursosRequest(pageNumber, pageSize);
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
}