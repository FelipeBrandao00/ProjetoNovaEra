using Application.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WEB.Models.Usuario;
using static WEB.Models.Genero.GeneroViewModel;
using static WEB.Models.Shared.ListarPadraoViewModel;

namespace WEB.Models.Professor
{
    public class ProfessorViewModel : UsuarioViewModel {
        public class ItemListaProfessor {
            public required Guid cdUsuario { get; set; }
            public required string nmUsuario { get; set; }
        }

        public async Task<Response<ResponseModelUsuario>> Habilitar(IConfiguration configuration, ResponseModelUsuario responseModelUsuario) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Professor/SetHabilitarProfessor";

                var Body = new {
                    cdProfessor = responseModelUsuario.CdUsuario
                };

                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelUsuario>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<Response<ResponseModelUsuario>> Desabilitar(IConfiguration configuration, ResponseModelUsuario responseModelUsuario) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Professor/SetDesabilitarProfessor";

                var Body = new {
                    cdProfessor = responseModelUsuario.CdUsuario
                };

                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");
                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelUsuario>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelUsuario> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<ResponseModelListaPadrao<ItemListaProfessor>> GerarLista(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Professor/GetProfessores?icHabilitadoTurma=true";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new ResponseModelListaPadrao<ItemListaProfessor> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ItemListaProfessor>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new ResponseModelListaPadrao<ItemListaProfessor> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new ResponseModelListaPadrao<ItemListaProfessor> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
