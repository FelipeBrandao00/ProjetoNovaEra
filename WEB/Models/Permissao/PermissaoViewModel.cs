using Application.Responses;
using System.Net.Http.Headers;
using System.Text.Json;
using WEB.Models.Response;

namespace WEB.Models.Permissao {
    public class PermissaoViewModel {
        public async Task<Response<List<ResponseModelPermissao>>> BuscarPermissoes(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Permissao";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new Response<List<ResponseModelPermissao>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<List<ResponseModelPermissao>>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<List<ResponseModelPermissao>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<List<ResponseModelPermissao>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
