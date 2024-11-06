using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using WEB.Models.Response;

namespace WEB.Models.Inscricao {
    public class InscricaoViewModel {
       
        public async Task<Response<ResponseModelInscricao>> Adicionar(IConfiguration configuration, ResponseModelInscricao responseModelInscricao) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Matricula";
                var Body = new
                {
                    nmUsuario = responseModelInscricao.DsNome,
                    dsEmail = responseModelInscricao.DsEmail,
                    dsCpf = responseModelInscricao.DsCPF,
                    dsGenero = responseModelInscricao.CdGenero,
                    dtNascimento = responseModelInscricao.DtNascimento,
                    dsTelefone = responseModelInscricao.DsTelefone,
                    cdTurma = responseModelInscricao.CdTurma
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelInscricao>>(responseBody, options);

                    return responseData;
                }
                catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelInscricao> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
