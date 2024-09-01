using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Responses;

namespace WEB.Models.EsqueciSenha;

public class EsqueciSenhaViewModel
{
    public string Email { get; set; }
    
    
     public async Task<ResponseModel> GetUsuarioByEmail(IConfiguration configuration, string email)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Usuario/getByEmail/{email}";
                var content = new StringContent("application/json");
                try
                {
                    var response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true, 
                        };
                        var responseData = JsonSerializer.Deserialize<Response<ResponseModel>>(responseBody, options);
                        if (responseData != null && responseData.IsSuccess && responseData.Data != null)
                        {
                            return responseData.Data;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public class ResponseModel
        {
            [JsonPropertyName("token")]
            public string Token { get; set; }

            [JsonPropertyName("tipo")]
            public string Tipo { get; set; }

            [JsonPropertyName("validoAte")]
            public DateTime ValidoAte { get; set; }
        }
}