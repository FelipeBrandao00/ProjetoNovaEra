using API.Models;
using Application.DTOs.Token;
using Application.Interfaces;
using Application.Requests.Usuarios;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController(IJwtService jwtService, IAuthenticateService authenticateService, IUsuarioService usuarioService, IEmailService emailService) : ControllerBase {
    [HttpPost("GerarToken")]
    public async Task<ActionResult> GerarToken([FromBody] User user) {
        var usuario = await authenticateService.Authenticate(user.Email, user.Password);
        if (usuario == null) return BadRequest(new Response<tokenDto>(null, 400, "Login e/ou Senha inválidos."));
        var response = jwtService.GerarToken(usuario);
        return Ok(response);
    }

    [HttpPost("EsqueciSenha")]
    public async Task<IActionResult> EsqueciSenha([FromBody] string email) {
        var request = new GetUsuarioByEmailRequest { Email = email };
        var user = await usuarioService.GetUsuarioByEmail(request);

        if (user.Data != null) {
            var resetToken = usuarioService.GeneratePasswordResetToken();
            await emailService.SendPasswordResetEmailAsync(user.Data.DsEmail, resetToken);

        }
        return Ok(new { Message = "Se existir uma conta com este e-mail, um código de redefinição de senha foi enviado." });
    }
}