using Application.Responses;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace WEB.Models.Turma {
    public class TurmaViewModel {
        public async Task<Response<ResponseModelTurma>> Adicionar(IConfiguration configuration, ResponseModelTurma responseModelTurma) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma";
                var Body = new {
                    dsTurma = responseModelTurma.DsTurma,
                    dtInicio = responseModelTurma.DtInicio,
                    cdProfessor = responseModelTurma.CdProfessor,
                    cdCurso = responseModelTurma.CdCurso
                    //adicionar o nome da turma
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelTurma> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelTurma>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelTurma> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelTurma> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
