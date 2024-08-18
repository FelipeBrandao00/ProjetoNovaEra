using API.Models;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController(IJwtService jwtService, IAuthenticateService authenticateService) : ControllerBase
{
    [HttpPost("")]
    public async Task<ActionResult> GerarToken([FromBody] User user) {
        var usuario = await authenticateService.Authenticate(user.Email, user.Password);
        if (usuario == null) return BadRequest("Login e/ou Senha inválidos.");
        var response = jwtService.GerarToken(usuario);
        return Ok(response);
    }
}