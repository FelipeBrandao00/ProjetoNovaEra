using Application.Responses;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

namespace WEB.Models.Turma {
    public class TurmaViewModel {
        public int id { get; set; }
        public async Task<Response<ResponseModelTurma>> BuscarInfo(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma/{id}";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
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
        public async Task<Response<List<ResponseModelTurma>>> TurmasAbertasMatricula(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma/GetTurmasAbertaMatricula";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<List<ResponseModelTurma>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<List<ResponseModelTurma>>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<List<ResponseModelTurma>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<List<ResponseModelTurma>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<ResponseModelTurma>> Adicionar(IConfiguration configuration, ResponseModelTurma responseModelTurma) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma";
                var Body = new {
                    nmTurma = responseModelTurma.NmTurma,
                    dsTurma = responseModelTurma.DsTurma,
                    dtInicio = DateTime.Now,
                    cdProfessor = responseModelTurma.CdProfessor,
                    cdCurso = responseModelTurma.CdCurso
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

        public async Task<Response<ResponseModelTurma>> AtualizarInfo(IConfiguration configuration, ResponseModelTurma ResponseModelTurma) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma/{ResponseModelTurma.CdTurma}";

                var content = new StringContent(JsonSerializer.Serialize(ResponseModelTurma), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PutAsync(url, content);
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

        public async Task<Response<ResponseModelTurma>> Reativar(IConfiguration configuration, ResponseModelTurma ResponseModelTurma) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma/ReativarTurma";

                var Body = new {
                    CdTurma = ResponseModelTurma.CdTurma
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

        public async Task<Response<ResponseModelTurma>> Desativar(IConfiguration configuration, ResponseModelTurma ResponseModelTurma) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma/DesativarTurma";

                var Body = new {
                    CdTurma = ResponseModelTurma.CdTurma
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

        public async Task<Response<ResponseModelTurma>> RetomarInscricao(IConfiguration configuration, ResponseModelTurma ResponseModelTurma) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma/HabilitarMatricula";

                var Body = new {
                    CdTurma = ResponseModelTurma.CdTurma
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

        public async Task<Response<ResponseModelTurma>> PararInscricao(IConfiguration configuration, ResponseModelTurma ResponseModelTurma) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma/EncerrarMatricula";

                var Body = new {
                    CdTurma = ResponseModelTurma.CdTurma
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
