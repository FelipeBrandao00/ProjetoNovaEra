using API.Models;
using Application.Interfaces;
using Application.Requests.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
{
    [HttpPost("api/[controller]")]
    public async Task<ActionResult> AddUsuario([FromBody] CreateUsuarioRequest request)
    {
       var result = await usuarioService.AddUsuario(request);
       if (!result.IsSuccess) return BadRequest(result);
       return Ok(result);
    }

    [HttpPut("api/[controller]/{id}")]
    public async Task<ActionResult> UpdateUsuario(Guid id,UpdateUsuarioRequest request)
    {
        if (id != request.cdUsuario) return new BadRequestResult();
        var result = await usuarioService.UpdateUsuario(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
    
    [HttpGet("api/[controller]/{cpf}")]
    public async Task<ActionResult> GetUsuarioByCpf(string cpf)
    {
        var request = new GetUsuarioByCpfRequest{Cpf = cpf};
        var result = await usuarioService.GetUsuarioByCpf(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
    
    [HttpGet("api/[controller]")]
    public async Task<ActionResult> GetUsuarios([FromQuery]int? pageNumber = null,[FromQuery]int? pageSize = null)
    {
        var request = new GetAllUsuariosRequest(pageNumber, pageSize);
        var result = await usuarioService.GetUsuarios(request);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}