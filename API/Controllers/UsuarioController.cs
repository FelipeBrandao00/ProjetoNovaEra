using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Models;
using Application.DTOs.Usuario;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController(IUsuarioService usuarioService, IConfiguration configuration) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddUsuario([FromBody] AddUsuarioDto user)
    {
       var result = await usuarioService.AddUsuario(user);
       if (result == null) return BadRequest();
       return Ok(result);
    }
    
    [HttpPost("/GerarToken")]
    public async Task<ActionResult> GerarToken([FromBody] User user) {
        var usuario = await usuarioService.Authenticate(user.Email, user.Password);
        if (usuario == null) return BadRequest("Login e/ou Senha inválidos.");
        
        var hadler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddMinutes(10),
            Subject = GetClaimsIdentity(user),
        };

        var token = hadler.CreateToken(tokenDescriptor);
        var strToken = hadler.WriteToken(token);
        return Ok(strToken);
    }
    
    private ClaimsIdentity GetClaimsIdentity(User user) {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        return claimsIdentity;
    }
}