using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Responses;

namespace WEB.Models.EsqueciSenha;

public class EsqueciSenhaViewModel
{
    public string Email { get; set; }
    
    
     public async Task<bool> RedefinirSenhaRequest(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Authenticate/EsqueciSenha";
                var Body = new
                {
                    email = this.Email,
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(url, content);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
     
        public async Task<bool> ValidarCodigo(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Usuario";
                var Body = new
                {
                    email = this.Email,
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PatchAsync(url, content);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
     
     
     
     
}