using static WEB.Models.Shared.ListarPadraoViewModel;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WEB.Models.Cargo {
    public class CargoViewModel {
        public class ItemListaCargo {
            public required int CdCargo { get; set; }
            public required string DsCargo { get; set; }
        }

        public async Task<ResponseModelListaPadrao<ItemListaCargo>> GerarLista(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Cargo";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return new ResponseModelListaPadrao<ItemListaCargo> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ItemListaCargo>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return new ResponseModelListaPadrao<ItemListaCargo> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                    return responseData;
                } catch (Exception ex) {
                    while (ex.InnerException != null) { ex = ex.InnerException; }
                    return new ResponseModelListaPadrao<ItemListaCargo> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
                }
            }
        }
    }
}
