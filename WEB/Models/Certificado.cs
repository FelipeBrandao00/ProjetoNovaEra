using Microsoft.AspNetCore.Mvc.Infrastructure;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace WEB.Models {
    public class Certificado {
        public static byte[] Gerar(byte[] arquivo, string? nmUsuario, DateTime? dtFinalizacao, string nmTurma) {
            using (var ms = new MemoryStream(arquivo)) {
                using (var bitmap = new Bitmap(ms)) {
                    using (var graphics = Graphics.FromImage(bitmap)) {
                        var font = new Font("Arial", 36, FontStyle.Bold);
                        var brush = new SolidBrush(Color.White);

                        var positionCertificado = new PointF(400, 400);
                        graphics.DrawString("Certificado de conclusão", font, brush, positionCertificado);

                        var positionName = new PointF(400, 500);
                        graphics.DrawString(nmUsuario, font, brush, positionName);

                        var positionNmTurma = new PointF(400, 600);
                        graphics.DrawString(nmTurma, font, brush, positionNmTurma);

                        var positionFinalizado = new PointF(400, 700);
                        graphics.DrawString($"Finalizado em: {String.Format("{0:dd/MM/yyyy}", dtFinalizacao)}", font, brush, positionFinalizado);

                        var positionEmitido = new PointF(400, 800);
                        graphics.DrawString($"Emitido em: {String.Format("{0:dd/MM/yyyy}", DateTime.Now)}", font, brush, positionEmitido);
                    }

                    using (var outputStream = new MemoryStream()) {
                        bitmap.Save(outputStream, ImageFormat.Jpeg);
                        return outputStream.ToArray();
                    }
                }
            }
        }

        public static async Task<SendGrid.Response> EnviarEmail(string toEmail, byte[] imagem) {
            string apiKey = "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";

            var client = new SendGridClient(apiKey);
            var senderEmail = new EmailAddress("suportenovaera9@gmail.com");
            var recieverEmail = new EmailAddress(toEmail);

            string emailSubject = "Encaminhar";
            string textContent = "Segue o documento solicitado em anexo.";
            var msg = MailHelper.CreateSingleEmail(senderEmail, recieverEmail, emailSubject, textContent, null);

            string base64Image = Convert.ToBase64String(imagem);
            msg.AddAttachment("documento.jpg", base64Image, "image/jpeg");

            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response;
        }
    }
}
