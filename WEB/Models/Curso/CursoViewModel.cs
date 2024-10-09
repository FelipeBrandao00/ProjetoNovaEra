using Application.Responses;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using WEB.Models.Shared;

namespace WEB.Models.Curso {
    public class CursoViewModel {
        public int id { get; set; }

        public async Task<Response<ResponseModelCurso>> BuscarInfo(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Curso/{id}";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelCurso>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<ResponseModelCurso>> Reativar(IConfiguration configuration, ResponseModelCurso responseModelCurso) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Curso/ReativarCurso";

                var Body = new {
                    CdCurso = responseModelCurso.CdCurso
                };

                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelCurso>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<ResponseModelCurso>> Finalizar(IConfiguration configuration, ResponseModelCurso responseModelCurso) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Curso/DesativarCurso";

                var Body = new {
                    CdCurso = responseModelCurso.CdCurso
                };

                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelCurso>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<ResponseModelCurso>> AtualizarInfo(IConfiguration configuration, ResponseModelCurso responseModelCurso) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Curso/{responseModelCurso.CdCurso}";

                var content = new StringContent(JsonSerializer.Serialize(responseModelCurso), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PutAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelCurso>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<ResponseModelCurso>> Adicionar(IConfiguration configuration, ResponseModelCurso responseModelCurso) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Curso";
                var Body = new {
                    nmCurso = responseModelCurso.NmCurso,
                    dsCurso = responseModelCurso.DsCurso,
                    dtCriacao = DateTime.Now
                };

                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelCurso>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelCurso> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
