using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.Services;

public class EmailService : IEmailService {
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration) {
        _configuration = configuration;
    }

    public async Task SendPasswordResetEmailAsync(string toEmail, string resetToken) {
        string apiKey = "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";

        var client = new SendGridClient(apiKey);
        var senderEmail = new EmailAddress("suportenovaera9@gmail.com");
        var recieverEmail = new EmailAddress(toEmail);

        string emailSubject = "Troca de Senha Nova Era";
        string textContent = $"O seu codigo de redefinição é:  {resetToken} ";
        var msg = MailHelper.CreateSingleEmail(senderEmail, recieverEmail, emailSubject, textContent, null);
        var resp = await client.SendEmailAsync(msg).ConfigureAwait(false);
    }
}