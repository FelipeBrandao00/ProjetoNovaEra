using Application.Responses;
using System.Net.Http.Headers;
using System.Text.Json;
using WEB.Models.Shared;
using static WEB.Models.Shared.ListarPadraoViewModel;

namespace WEB.Models.Genero;

public class GeneroViewModel
{
    public class ItemListaGenero
    {
        public required int CdGenero { get; set; }
        public required string NmGenero { get; set; }
    }

    public async Task<ResponseModelListaPadrao<ItemListaGenero>> GerarLista(IConfiguration configuration)
    {
        using (var client = new HttpClient())
        {
            var baseUrl = configuration["BaseRequest"];
            var url = $"{baseUrl}/Genero";

            var token = configuration["JwtToken"];
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new ResponseModelListaPadrao<ItemListaGenero> { Data = null, IsSuccess = false, Message = "Erro no retorno da requisição." };

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ItemListaGenero>>(responseBody, options);

                if (responseData == null || !responseData.IsSuccess)
                    return new ResponseModelListaPadrao<ItemListaGenero> { Data = null, IsSuccess = false, Message = "Erro no conteúdo retornado pela requisição." };

                return responseData;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) { ex = ex.InnerException; }
                return new ResponseModelListaPadrao<ItemListaGenero> { Data = null, IsSuccess = false, Message = "Erro ao tentar fazer a requisição para a API: \r\n" + ex.Message };
            }
        }
    }
}