using Application.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WEB.Models.Response;
using static WEB.Models.Cargo.CargoViewModel;
using static WEB.Models.Shared.ListarPadraoViewModel;

namespace WEB.Models.CargoUsuario {
    public class CargoUsuarioViewModel {
        public class ItemListaCargoUsuario {
            public required int CdCargo { get; set; }
            public required string DsCargo { get; set; }

        }
        public async Task<Response<List<ResponseModelCargoUsuario>>> AddCargosUsuario(IConfiguration configuration, Guid cdUsuario, int[] cdCargos) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/CargoUsuario/AddCargosUsuario";

                var Body = new {
                    CdUsuario = cdUsuario,
                    CdCargos = cdCargos
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<List<ResponseModelCargoUsuario>> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<List<ResponseModelCargoUsuario>>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<List<ResponseModelCargoUsuario>> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<List<ResponseModelCargoUsuario>> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
        public async Task<Response<ResponseModelCargoUsuario>> AddCargoUsuario(IConfiguration configuration, Guid cdUsuario, int cdCargo) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/CargoUsuario";

                var Body = new {
                    CdUsuario = cdUsuario,
                    CdCargo = cdCargo
                };
                var content = new StringContent(JsonSerializer.Serialize(Body), Encoding.UTF8, "application/json");

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                        return new Response<ResponseModelCargoUsuario> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ResponseModelCargoUsuario>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new Response<ResponseModelCargoUsuario> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new Response<ResponseModelCargoUsuario> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }

        public async Task<ResponseModelListaPadrao<ItemListaCargoUsuario>> ListarCargoUsuario(IConfiguration configuration, Guid cdUsuario) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/CargoUsuario";

                    url += $"?cdUsuario={cdUsuario}";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new ResponseModelListaPadrao<ItemListaCargoUsuario> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ItemListaCargoUsuario>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new ResponseModelListaPadrao<ItemListaCargoUsuario> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new ResponseModelListaPadrao<ItemListaCargoUsuario> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
