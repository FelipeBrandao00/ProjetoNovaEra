using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Responses;

namespace WEB.Models.EsqueciSenha;

public class EsqueciSenhaViewModel
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NovaSenha { get; set; }
    public string SenhaConfirmada { get; set; }
    
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
            var url = $"{baseUrl}/Authenticate/ValidarTokenRedefinicao";
            var Body = new
            {
                Email = this.Email,
                DsToken = this.Token
            };
            var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode) return false;
                
                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<ResponseModelToken>>(responseBody, options);
                if (responseData == null || !responseData.IsSuccess || responseData.Data == null) return false;
                return responseData.Data.Valido;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public async Task<bool> RedefinirSenha(IConfiguration configuration)
    {
        using (var client = new HttpClient())
        {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Usuario";
            var Body = new
            {
                Email = this.Email,
                NewPassword = this.NovaSenha
            };
            var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PatchAsync(url, content);
                if (!response.IsSuccessStatusCode) return false;
                
                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<Response<ResponseModelUsuario>>(responseBody, options);
                if (responseData == null || !responseData.IsSuccess || responseData.Data == null) return false;
                return responseData.IsSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
     
    public class ResponseModelToken
    {
        [JsonPropertyName("Valido")]
        public bool Valido { get; set; }
            
    }
}