﻿using Application.Interfaces;
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
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddMatricula([FromBody] AddMatriculaRequest request)
        {
            var result = await matriculaService.AddMatricula(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }


        [HttpGet("api/[controller]/GetMatriculasByTurmaId/{tumraId:int}")]
        public async Task<ActionResult> GetMatriculasByTurmaId(int tumraId, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null)
        {
            var request = new GetMatriculasByTurmaIdRequest(pageNumber, pageSize, tumraId);
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