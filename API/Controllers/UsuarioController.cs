﻿using Application.Interfaces;
using Application.Requests.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Administrador, Professor, Master")]
[ApiController]
public class UsuarioController(IUsuarioService usuarioService) : ControllerBase {
    [HttpPost("api/[controller]")]
    public async Task<ActionResult> AddUsuario([FromBody] CreateUsuarioRequest request) {
        var result = await usuarioService.AddUsuario(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpPut("api/[controller]/{id:guid}")]
    public async Task<ActionResult> UpdateUsuario(Guid id, UpdateUsuarioRequest request) {
        if (id != request.CdUsuario) return new BadRequestResult();
        var result = await usuarioService.UpdateUsuario(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("api/[controller]/{cpf}")]
    public async Task<ActionResult> GetUsuarioByCpf(string cpf) {
        var request = new GetUsuarioByCpfRequest { Cpf = cpf };
        var result = await usuarioService.GetUsuarioByCpf(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("api/[controller]/GetUsuarioByEmail/{email}")]
    public async Task<ActionResult> GetUsuarioByEmail(string email) {
        var request = new GetUsuarioByEmailRequest { Email = email };
        var result = await usuarioService.GetUsuarioByEmail(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("api/[controller]")]
    public async Task<ActionResult> GetUsuarios([FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
        var request = new GetAllUsuariosRequest(pageNumber, pageSize);
        var result = await usuarioService.GetUsuarios(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("api/[controller]/getByCargo/{cdCargo:int}")]
    public async Task<ActionResult> GetUsuariosByCargo(int cdCargo, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
        var request = new GetAllUsuariosByCargoRequest(cdCargo, pageNumber, pageSize);
        var result = await usuarioService.GetUsuariosByCargo(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPatch("api/[controller]")]
    public async Task<ActionResult> UpdateUsuario(UpdateUsuarioPasswordRequest request) {
        var result = await usuarioService.UpdatePasswordUsuario(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("api/[controller]/getByCargos")]
    public async Task<ActionResult> GetUsuariosByCargos([FromQuery] int[] cdCargo, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
        var request = new GetUsuariosByCargosRequest(cdCargo, pageNumber, pageSize);
        var result = await usuarioService.GetUsuariosByCargos(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}

