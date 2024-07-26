using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Models;
using Application.DTOs.Usuario;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController(IUsuarioService usuarioService, IJwtService jwtService) : ControllerBase
{
    
    [HttpPost("/AddUsuario")]
    [Authorize(Roles = "Admnistrador")]
    public async Task<ActionResult> AddUsuario([FromBody] AddUsuarioRequestDto user)
    {
       var result = await usuarioService.AddUsuario(user);
       return Ok(result);
    }
    
    [HttpGet("/GetUsuarioByCpf")]
    [Authorize(Roles = "Admnistrador")]
    public async Task<ActionResult> GetUsuarioByCpf(string cpf)
    {
        var result = await usuarioService.GetUsuarioByCpf(cpf);
        return Ok(result);
    }
    
    [HttpGet("/GetUsuarios")]
    [Authorize(Roles = "Admnistrador")]
    public async Task<ActionResult> GetUsuarios()
    {
        var result = await usuarioService.GetUsuarios();
        return Ok(result);
    }
    
    [HttpPost("/Authenticate")]
    public async Task<ActionResult> GerarToken([FromBody] User user) {
        var usuario = await usuarioService.Authenticate(user.Email, user.Password);
        if (usuario == null) return BadRequest("Login e/ou Senha inválidos.");
        var token = jwtService.GerarToken(usuario);
        return Ok(token);
    }
}