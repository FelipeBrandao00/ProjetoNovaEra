using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using DotNetEnv;

namespace Application.Services;

public class EmailService : IEmailService {
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration) {
        _configuration = configuration;
    }

    public async Task SendPasswordResetEmailAsync(string toEmail, string resetToken) {
        Env.Load();
        string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

        var client = new SendGridClient(apiKey);
        var senderEmail = new EmailAddress("suportenovaera9@gmail.com");
        var recieverEmail = new EmailAddress(toEmail);

        string emailSubject = "Troca de Senha Nova Era";
        string textContent = $"O seu codigo de redefinição é:  {resetToken} ";
        var msg = MailHelper.CreateSingleEmail(senderEmail, recieverEmail, emailSubject, textContent, null);
        var resp = await client.SendEmailAsync(msg).ConfigureAwait(false);
    }
}