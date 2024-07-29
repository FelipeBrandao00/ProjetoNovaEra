using API.Models;
using Application.Interfaces;
using Application.Requests.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[Authorize(Roles = "Admnistrador")]
[ApiController]
public class UsuarioController(IUsuarioService usuarioService, IJwtService jwtService) : ControllerBase
{
    [HttpPost("/AddUsuario")]
    public async Task<ActionResult> AddUsuario([FromBody] CreateUsuarioRequest request)
    {
       var result = await usuarioService.AddUsuario(request);
       return Ok(result);
    }

    [HttpPut("/UpdateUsuario")]
    public async Task<ActionResult> UpdateUsuario(Guid id,UpdateUsuarioRequest request)
    {
        if (id != request.cdUsuario) return new BadRequestResult();
        var result = await usuarioService.UpdateUsuario(request);
        return Ok(result);
    }
    
    [HttpGet("/GetUsuarioByCpf")]
    public async Task<ActionResult> GetUsuarioByCpf(string cpf)
    {
        var request = new GetUsuarioByCpfRequest{Cpf = cpf};
        var result = await usuarioService.GetUsuarioByCpf(request);
        return Ok(result);
    }
    
    [HttpGet("/GetUsuarios")]
    public async Task<ActionResult> GetUsuarios([FromQuery]int? pageNumber = null,[FromQuery]int? pageSize = null)
    {
        var request = new GetAllUsuariosRequest(pageNumber, pageSize);
        var result = await usuarioService.GetUsuarios(request);
        return Ok(result);
    }
    
    [HttpPost("/Authenticate")]
    [AllowAnonymous]
    public async Task<ActionResult> GerarToken([FromBody] User user) {
        var usuario = await usuarioService.Authenticate(user.Email, user.Password);
        if (usuario == null) return BadRequest("Login e/ou Senha inválidos.");
        var token = jwtService.GerarToken(usuario);
        return Ok(token);
    }
}