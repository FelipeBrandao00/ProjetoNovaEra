﻿using Application.Interfaces;
using Application.Requests.Curso;
using Application.Requests.Generos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Authorize(Roles = "Administrador, Master, Professor")]
    [ApiController]
    public class GeneroController(IGeneroService generoService) : ControllerBase {
        [HttpGet("api/[controller]/{id:int}")]
        public async Task<ActionResult> GetGeneroById(int id) {
            var request = new GetGeneroByIdRequest() { CdGenero = id };
            var result = await generoService.GetGeneroById(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("api/[controller]")]
        public async Task<ActionResult> GetGeneros([FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
            var request = new GetGenerosRequest(pageNumber, pageSize);
            var result = await generoService.GetGeneros(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
