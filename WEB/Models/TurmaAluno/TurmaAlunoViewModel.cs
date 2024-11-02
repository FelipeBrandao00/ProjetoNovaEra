using Application.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WEB.Models.TurmaAluno {
    public class TurmaAlunoViewModel {
        public int cdTurma { get; set; }
        public Guid cdAluno { get; set; }
        public bool icAprovado { get; set; }
        public string dsTurma { get; set; }
        public int cdCurso { get; set; }
        public string nmCurso { get; set; }

        public async Task<Response<List<TurmaAlunoViewModel>>> DesvincularAluno(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/TurmaAluno";

                var Body = new {
                    CdTurma = cdTurma,
                    CdAluno = cdAluno
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.DeleteAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<List<TurmaAlunoViewModel>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<List<TurmaAlunoViewModel>>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<List<TurmaAlunoViewModel>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<List<TurmaAlunoViewModel>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
