using Application.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WEB.Models.Response;
using WEB.Models.Usuario;

namespace WEB.Models.Matricula {
    public class MatriculaViewModel {
        public int cdMatricula { get; set; }
        public string nmUsuario { get; set; }
        public string dsCpf { get; set; }
        public string dsEmail { get; set; }
        public int cdTurma { get; set; }
        public string nmTurma { get; set; }
        public int dsGenero { get; set; }
        public string strDsGenero { get; set; }
        public DateTime dtNascimento { get; set; }
        public string dsTelefone { get; set; }
        public bool? icAtendeFiltro { get; set; }

        public async Task<Response<List<MatriculaViewModel>>> BuscarPorTurma(IConfiguration configuration, ResponseModelMatricula ResponseModelMatricula) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Matricula/GetMatriculasByTurmaId/{ResponseModelMatricula.cdTurma}";

                if (ResponseModelMatricula.icExAluno != null || ResponseModelMatricula.idadeInicial != null || ResponseModelMatricula.idadeFinal != null) {
                    url += "?";
                }

                if (ResponseModelMatricula.idadeInicial != null) {
                    url += $"idadeInicial={ResponseModelMatricula.idadeInicial}&";
                }
                if (ResponseModelMatricula.idadeFinal != null) {
                    url += $"idadeFinal={ResponseModelMatricula.idadeFinal}&";
                }
                if (ResponseModelMatricula.icExAluno != null) {
                    url += $"icExAluno={ResponseModelMatricula.icExAluno.ToString().ToLower()}";
                }
                if (url.EndsWith("&")) {
                    url = url.Remove(url.Length - 1);
                }

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<List<MatriculaViewModel>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<List<MatriculaViewModel>>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<List<MatriculaViewModel>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<List<MatriculaViewModel>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<MatriculaViewModel>> GetById(IConfiguration configuration, int cdMatricula)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Matricula/GetMatriculaById/{cdMatricula}";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<MatriculaViewModel> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<MatriculaViewModel>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<MatriculaViewModel> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<MatriculaViewModel> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
        public async Task<Response<List<ResponseModelUsuario>>> EfetivarMatriculas(IConfiguration configuration, int[] idMatriculas)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Matricula/EfetivarMatriculas";

                var Body = new {
                    matriculaIds = idMatriculas
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<List<ResponseModelUsuario>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<List<ResponseModelUsuario>>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<List<ResponseModelUsuario>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<List<ResponseModelUsuario>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
