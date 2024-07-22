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
    
    [HttpPost]
    [Authorize(Roles = "Admnistrador,Professor")]
    public async Task<ActionResult> AddUsuario([FromBody] AddUsuarioDto user)
    {
       var result = await usuarioService.AddUsuario(user);
       return Ok(result);
    }
    
    [HttpPost("/GerarToken")]
    public async Task<ActionResult> GerarToken([FromBody] User user) {
        var usuario = await usuarioService.Authenticate(user.Email, user.Password);
        if (usuario == null) return BadRequest("Login e/ou Senha inválidos.");
        var token = jwtService.GerarToken(usuario);
        return Ok(token);
    }
}