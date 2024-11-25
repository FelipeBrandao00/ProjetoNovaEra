using API.Models;
using Application.DTOs.Token;
using Application.Interfaces;
using Application.Requests.PasswordChange;
using Application.Requests.Usuarios;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController(IJwtService jwtService, IAuthenticateService authenticateService, IUsuarioService usuarioService, IEmailService emailService, IPasswordChangeService passwordChangeService) : ControllerBase {
    [HttpPost("GerarToken")]
    public async Task<ActionResult> GerarToken([FromBody] User user) {
        var usuario = await authenticateService.Authenticate(user.Email, user.Password);
        if (usuario == null) return BadRequest(new Response<tokenDto>(null, 400, "Login e/ou Senha inválidos."));
        var response = jwtService.GerarToken(usuario);
        return Ok(response);
    }

    [HttpPost("EsqueciSenha")]
    public async Task<IActionResult> EsqueciSenha([FromBody] GetUsuarioByEmailRequest request) {
        var user = await usuarioService.GetUsuarioByEmail(request);

        if (user.Data != null) {
            var resetToken = usuarioService.GeneratePasswordResetToken();
            var requestPasswordChange = new AddPasswordChangeRequest
            {
                CdUsuario = user.Data.CdUsuario,
                DsCodigoRedefinicao = resetToken,
                DtValidade = DateTime.Now.AddMinutes(15)
            };
            await passwordChangeService.AddPasswordChange(requestPasswordChange);
            await emailService.SendPasswordResetEmailAsync(user.Data.DsEmail, resetToken);
        }
        return Ok();
    }

    [HttpPost("ValidarTokenRedefinicao")]
    public async Task<IActionResult> ValidarTokenRedefinicao([FromBody] VerifyPasswordChangeCodeRequest request) {
        var result = await passwordChangeService.VerifyPasswordChangeCode(request);
        return Ok(result);
    }
}